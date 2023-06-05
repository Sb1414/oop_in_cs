# oop_in_cs

> Решение задач на C#

## Table of contents

1. [Student Group](#studentgroup)
2. [Credit](#credit)
3. [Figure](#figure)
3. [Class hierarchy](#class-hierarchy)
4. [Polymorphic container object](#polymorphic-container-object)
5. [Diamond-shaped class inheritance](#diamond-shaped-class-inheritance)
6. [Printer maintenance](#printer-maintenance)
7. [Credit Organization](#credit-organization)

## StudentGroup
#### Задача: должен быть создан класс студент, и класс объектов студентов. Необходимо реализовать удаление студента, вывод всей информации, корректировку информации в консоли и приложении
</br>код реализации находится [здесь](1_task/)

## Credit
#### Задача: должен быть создан класс кредитоплательщика, и класс объектов кредитоплательщиков. Необходимо реализовать добавление кредитоплательщика, удаление кредитоплательщика, вывод всей информации о кредитоплательщиках, вывод информации по конкретному кредитоплательщику, корректировку информации, сумма всех выплат и всех кредитов. Консольная и оконная реализация
</br>код реализации находится [здесь](2-4_task/)

## Figure
#### Задача: требуется создать небольшую иерархию классов, описывающих основные графические примитивы "окружность, прямоугольник, эллипс, квадрат" на основе использования механизмов наследования, виртуальных методов и полиморфных объектных переменных.
</br>код реализации находится [здесь](5_task/)


## Class hierarchy
#### На сайте хранятся публикации двух видов:
- новость (с параметром «источник»);
- статья (с параметром «автор»).
#### Требуется создать небольшую иерархию классов для хранения и обработки минимально необходимого набора данных о публикациях обоих типов с возможностью вывода индивидуальных данных в зависимости от типа публикации.
#### Примерная структура классов:
- абстрактный корневой класс «Публикация»: заголовок, конструктор, методы доступа, абстрактный виртуальный метод вывода данных.
- производный класс «Новость»: источник, конструктор, методы доступа, переопределенный метод вывода данных.
- производный класс «Статья»; автор, конструктор, методы доступа, переопределенный метод вывода данных.

</br>код реализации находится [здесь](6_task/)

 ## Polymorphic container object
#### Задача: спроектировать и реализовать полиморфный объект-контейнер для хранения и обработки данных о публикациях двух типов (новость и статья), объединенных общей иерархией. Контейнер должен обеспечивать возможность добавления публикаций, запрос данных о публикации и вывод полного списка публикаций с разными данными в соответствии с типом публикации.
</br>код реализации находится [здесь](7-8_task/)

## Diamond-shaped class inheritance
#### Задача: реализовать приложение для хранения и обработки минимального набора данных о студентах и сотрудниках учебного заведения, включая отработку гибридной ситуации c сотрудниками-студентами. Для хранения данных использовать контейнер-массив полиморфных ссылок.
#### Требования к работе:
1. Использование небольшой иерархии классов с базовым классом Человек и дочерними классами Студент, Сотрудник и СтудентСотрудник
2. В классе Человек предусмотреть обработку только фамилии, в классе Студент добавить обработку оплаты за обучение, в классе Сотрудник обработку зарплаты, a в гибридном СтудентСотрудник добавить обработку как оплаты, так зарплаты
3. Предусмотреть наличие необходимых интерфейсных классов для отработки ситуации ромбовидного наследования
4. Наличие минимально необходимого набора методов объекта- контейнера, таких как добавление в конец набора, запрос данных по конкретному объекту, вывод всех данных всех объектов.
5. Проверка всех методов с помощью консольного приложения. 

</br>код реализации находится [здесь](9_task/)

## Printer maintenance
#### В организации используются принтеры двух типов:
- лазерные (параметр - объем картриджа)
- струйные (параметр число цветов)
#### Требуется создать небольшую иерархию классов для хранения и обработки минимально необходимого набора данных о принтерах обоих типов с возможностью вывода индивидуальных данных в зависимости от типа принтера.
#### Примерная структура классов:
- абстрактный корневой класс "Принтеры": скорость
печати, конструктор, методы доступа, абстрактный виртуальный выводы данных.
- производный класс «ЛазерныйПринтер»: объем картридж, конструктор, методы доступа, переопределенный метод вывод данных
- производный класс «СтруйныйПринтер»: число цветов, конструктор, методы доступа, переопределенный метод вывода данных. 
#### Спроектировать и реализовать полиморфный объект-контейнер для хранения и обработки данных принтерах двух типов (лазерные и струйные), объединенных общей иерархией. Контейнер должен обеспечивать возможность добавления принтера, запрос данных о принтере и вывод полного списка принтеров с разными данными в соответствии с типом принтера.

</br>код реализации находится [здесь](Printer_7_task/) и [здесь](Printer_8_task/)

## Credit Organization
#### Кредитная организация ведет учет выданных кредитов двух видов: ипотечный и автокредит. Для ипотечного кредита хранятся данные об адресе проживания, а для автокредита марка автомобиля. Требуется создать небольшую иерархию классов для хранения и обработки минимально необходимого набора данных о кредитах обоих типов с возможностью вывода индивидуальных данных в зависимости от типа кредита.
#### Примерная структура классов:
- абстрактный корневой класс «Кредит»: ФИО, сумма кредита, конструктор, методы доступа, абстрактный виртуальный метод вывод данных.
- производный класс «Ипотека»: адрес проживания, конструктор, методы доступа, переопределенный метод вывода данных. 
- производный класс «Автокредит»: Марка автомобиля, конструктор, методы доступа, переопределенный метод вывода данных.
#### Спроектировать и реализовать полиморфный объект-контейнер для хранения и обработки данных о кредитах двух типов (ипотечный и автокредит), объединенных общей иерархией. Контейнер должен обеспечивать возможность добавления кредитов, запрос данных о кредите и вывод полного списка кредитов с разными данными в соответствии с типом кредита.
</br>код реализации находится [здесь](7_task_CreditOrganization/) и [здесь](8_task_CreditOrganization/)