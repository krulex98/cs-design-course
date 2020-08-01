﻿## Практика «Структура данных»

Простейший сценарий, когда вам нужна перегрузка методов и реализация интерфейсов - написание небольших структур данных, которые должны быть совместимы с листами, словарями и т.д.

Допустим, вы разрабатываете систему для анализа сообщений в техподдержку, и хотите классифицировать их по имени продукту, типу сообщения и его теме. Соответственно, вам необходим класс, обозначающий категорию сообщений с указанными полями.

Скачайте проект [Inheritance.DataStucture](https://ulearn.me/Exercise/StudentZip?courseId=cs2&slideId=1cb3fef1-004f-45df-a94a-412aa744ed2a) и создайте класс Category.cs. В этом классе переопределите методы Equals и GetHashCode, реализуйте интерфейс IComparable, упорядочивающий категории сначала по продукту, затем по типу и затем - по теме, а также реализуйте все операторы сравнения. Изучите тесты для того, чтобы понять детали реализации.