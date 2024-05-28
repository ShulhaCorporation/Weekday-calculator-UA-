using System;
class HelloWorld {
    static int year;
    static int month;
    static int day;
    static bool isLeap;
    static int monthCode;
    static int centuryCode;
    static int yearCode;
    static int weekDay;
  static void Main() {
    Console.WriteLine("Калькулятор дня тижня за датою");
    
    Console.WriteLine("Введіть рік");
    int.TryParse(Console.ReadLine(), out year);
    isLeap = LeapCheck();
    
    monthMark:
    
    Console.WriteLine("Введіть число місяця");
    int.TryParse(Console.ReadLine(), out month);
    
    if(month < 1 || month > 12){
        Console.WriteLine("Такого місяця не існує");
        goto monthMark;
    }
    
    dayMark:
    Console.WriteLine("Введіть день");
    int.TryParse(Console.ReadLine(), out day);
    if(day < 1 || day > 31){
         Console.WriteLine("Такого дня не існує");
         goto dayMark;
    }
    if(day == 31){
        if(month == 2 || month == 4 || month == 6 || month == 9 || month == 11){
        Console.WriteLine("Такого дня не існує");
         goto dayMark;
        }
    }
    else if(day > 28 && month == 2 && !isLeap){
        Console.WriteLine("Такого дня не існує");
         goto dayMark;
    }
    else if(day > 29 && month == 2 && isLeap){
        Console.WriteLine("Такого дня не існує");
         goto dayMark;
    }
    
     MonthCoding();
     YearCoding();
     WeekCounting();
  }
  static bool LeapCheck(){
      
        if(year % 4 == 0){
        if(year % 100 == 0 && year % 400 != 0){
            return false;
        }
        else if (year % 400 == 0){
           return true;
        }
        else{
          return true;
        }
    }
    else{
       return false;
    }
  }
  static void YearCoding(){
      CenturyCoding();
      int lastDigits = year % 100;
      int almostYearCode = centuryCode + lastDigits + lastDigits/4;
      yearCode = almostYearCode % 7;
  }
  static void CenturyCoding(){
       int century = year / 100;
      if(century % 4 == 0){
          centuryCode = 6;
      }
       if(century % 4 == 1){
          centuryCode = 4;
      }
       if(century % 4 == 2){
          centuryCode = 2;
      }
       if(century % 4 == 3){
          centuryCode = 0;
      }
  }
  static void MonthCoding(){
      if(month == 1 && !isLeap){
          monthCode = 1;
      }
      if(month == 1 && isLeap){
          monthCode = 0;
      }
      if(month == 2 && !isLeap){
          monthCode = 4;
      }
      if(month == 2 && isLeap){
          monthCode = 3;
      }
      if(month == 3 || month == 11){
          monthCode = 4;
      }
      if(month == 4 || month == 7){
          monthCode = 0;
      }
      if(month == 5){
          monthCode = 2;
      }
       if(month == 6){
          monthCode = 5;
      }
       if(month == 8){
          monthCode = 3;
      }
       if(month == 9 || month == 12){
          monthCode = 6;
      }
      if(month == 10){
          monthCode = 1;
      }
  }
  static void WeekCounting(){
      int almostWeekDay = day + monthCode + yearCode;
      weekDay = almostWeekDay % 7;
      if(weekDay == 0){
          Console.WriteLine("Субота");
      }
      if(weekDay == 1){
          Console.WriteLine("Неділя");
      }
      if(weekDay == 2){
          Console.WriteLine("Понеділок");
      }
      if(weekDay == 3){
          Console.WriteLine("Вівторок");
      }
      if(weekDay == 4){
          Console.WriteLine("Середа");
      }
      if(weekDay == 5){
          Console.WriteLine("Четвер");
      }
      if(weekDay == 6){
          Console.WriteLine("П'ятниця");
      }
  }
}


