using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MillisecondsSince19700101
{

    public class DateSince19700101
    {
        /// <summary>
        /// Год
        /// </summary>
        private int Year { get; set; }
        /// <summary>
        /// Месяц
        /// </summary>
        private int Month { get; set; }
        /// <summary>
        /// День
        /// </summary>
        private int Day { get; set; }
        /// <summary>
        /// Час
        /// </summary>
        private int Hour { get; set; }
        /// <summary>
        /// Минута
        /// </summary>
        private int Minutes { get; set; }
        /// <summary>
        /// Секунда
        /// </summary>
        private int Seconds { get; set; }
        /// <summary>
        /// Миллисекунда
        /// </summary>
        private int Millisecond { get; set; }

        /// <summary>
        /// Передаем миллисекунды, получаем дату
        /// </summary>
        /// <param name="milliseconds"></param>
        public DateSince19700101(long milliseconds)
        {
            DateSince19700101 dateSince19700101 = GetDateFromMilliseconds(milliseconds);
            Year = dateSince19700101.Year;
            Month = dateSince19700101.Month;
            Day = dateSince19700101.Day;
            Hour = dateSince19700101.Hour;
            Minutes = dateSince19700101.Minutes;
            Seconds = dateSince19700101.Seconds;
            Millisecond = dateSince19700101.Millisecond;
        }

        /// <summary>
        /// Формируем дату
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public DateSince19700101(int year, int month, int day, int hour, int minutes, int seconds, int milliseconds)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minutes = minutes;
            Seconds = seconds;
            Millisecond = milliseconds;
        }

        /// <summary>
        /// Преобразуем миллисекунды в дату от 01.01.1970 
        /// </summary>
        /// <param name="milliseconds"></param>
        private DateSince19700101 GetDateFromMilliseconds(long milliseconds)
        {
            int year = 1970;
            int month = 1;
            int day = 1;
            int hour = 0;
            int minutes = 0;
            int second = 0;
            int millisecond = 0;

            long millisecondInYear;

            // Если миллисекунд больше одного года

            do
            {
                millisecondInYear = MillisecondInYear(year);

                if ((milliseconds - millisecondInYear) < 0) break;
                milliseconds -= millisecondInYear;

                year++;

            } while ((milliseconds - millisecondInYear) > 0);

            bool isLeapYear = IsLeapYear(year);
            for (int i = 1; i <= 12; i++)
            {
                long millisecondInMonth = MillisecondInMonth(i, isLeapYear);

                // Если миллисекунд не хватает на еще один месяц, то выходим
                if ((milliseconds - millisecondInMonth) < 0) break;

                milliseconds -= millisecondInMonth;

                month++;
            }

            long daysInMonth = DayInMonth(month, isLeapYear);
            for (int i = 1; i <= daysInMonth; i++)
            {
                long millisecondInDay = MillisecondInDay;

                if((milliseconds - millisecondInDay) < 0) break;

                milliseconds -= millisecondInDay;

                day++;
            }

            for (int i = 1; i <= 24; i++)
            {
                long millisecondInHour = MillisecondInHour;

                if((milliseconds - millisecondInHour) < 0) break;

                milliseconds -= millisecondInHour;

                hour++;
            }

            for (int i = 1; i <= 60; i++)
            {
                long millisecondInMinute = MillisecondInMinute;

                if((milliseconds - millisecondInMinute) < 0) break;

                milliseconds -= millisecondInMinute;

                minutes++;
            }

            for (int i = 1; i <= 60; i++)
            {
                long millisecondInSecond = MillisecondInSecond;

                if((milliseconds - millisecondInSecond) < 0) break;

                milliseconds -= millisecondInSecond;

                second++;
            }

            millisecond = (int)milliseconds;

            return new DateSince19700101(year, month, day, hour, minutes, second, millisecond);
        }

        public override string ToString()
        {
            return string.Format("{0:00}.{1:00}.{2} {3:00}:{4:00}:{5:00}.{6}", Day, Month, Year, Hour, Minutes, Seconds, Millisecond);
        }

        /// <summary>
        /// Високосный ли год?
        /// </summary>
        private bool IsLeapYear(long year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        /// <summary>
        /// Миллисекунд в день
        /// </summary>
        /// <returns></returns>
        private long MillisecondInDay
        {
            get { return 1000 * 60 * 60 * 24; }
        }

        /// <summary>
        /// Миллисекунд в час
        /// </summary>
        private long MillisecondInHour
        {
            get { return 1000*60*60; }
        }

        /// <summary>
        /// Миллисекунд в минуту
        /// </summary>
        private long MillisecondInMinute
        {
            get { return 1000*60; }
        }

        /// <summary>
        /// Миллисекунды в секунду
        /// </summary>
        private long MillisecondInSecond
        {
            get { return 1000; }
        }

        /// <summary>
        /// Миллисекунд в месяц
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private long MillisecondInMonth(int month, bool isLeapYear)
        {
            int days = DayInMonth(month, isLeapYear);
            return MillisecondInDay * days;
        }

        /// <summary>
        /// Миллисекунд в году
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private long MillisecondInYear(int year)
        {
            bool isLeapYear = IsLeapYear(year);

            long millisecondInMonth = 0;
            for (int i = 1; i <= 12; i++)
            {
                millisecondInMonth += MillisecondInMonth(i, isLeapYear);
            }

            return millisecondInMonth;
        }

        /// <summary>
        /// Последний день в месяце
        /// </summary>
        /// <param name="month"></param>
        /// <param name="isLeapYear"></param>
        /// <returns></returns>
        private int DayInMonth(int month, bool isLeapYear)
        {
            int daysInMonth = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    daysInMonth = 31;
                    break;
                case 2:
                    daysInMonth = isLeapYear ? 29 : 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    daysInMonth = 30;
                    break;
                default:
                    new ArgumentOutOfRangeException(string.Format("Передан месяц который выходит за пределы допустимых значений - {0}", month));
                    break;
            }

            return daysInMonth;
        }

        /// <summary>
        /// Для тестов, не относиться к функционалу
        /// Проверяем правильность реализованного функционала
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            DateTime dateTime = new DateTime(Year, Month, Day, Hour, Minutes, Seconds, Millisecond);
            return dateTime;
        }
    }
}
