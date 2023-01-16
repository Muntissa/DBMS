# Курсовая работа по СУБД
Тема - АРМ администратора гостиницы.


Солюшн включает в себя три проекта:
1. DBMS.Api - api приложения;
2. DBMS.ConsoleTests - название говорит само за себя:
3. DBMS.Web - само веб-приложение.

В данной работе была попытка создания самописной ORM. В дальнейшем есть желание развития этой идеи.

# Используемые технологии
C# Asp.Net Razor Pages, JavaScript datatables.net для менеджемента тейблов в хтмл.

# Экспорт/Импорт БД
База данных находится на верхнем уровне проекта с расширением .bacpac
1. Экспорт: Microsoft SQL SMS -> ПКМ по БД -> Tasks -> Export Data-tier Application;
1. Импорт: Microsoft SQL SMS -> ПКМ по Databases -> Import Data-tier Application;
