﻿##Практика «Геометрия-1»
Какое же наследование без геометрии!

Скачайте проект Inheritance.Geometry и изучите Task.cs. Проблема этого подхода в том, что каждый раз при добавлении нового типа тела придется менять метод в базовом классе.

Предположим вы знаете, что в планах добавить ещё много новых геометрических примитивов. В этом случае разумно сделать метод GetVolume абстрактным и переопределить его в классах Cube, Ball и Cyllinder.

Сделайте это!

В финальном решении не должно быть ни одного приведения типа.

## Практика «Геометрия-2»
Давайте теперь предположим, что в предыдущей задаче новых геометрических примитивов добавлять мы не собираемся. Зато собираемся добавлять новые методы для работы с уже имеющимися — они могут вычислять объем, площадь поверхности, рассчитывать точку пересечения объекта с прямой и т.д.

В этом случае часто используется шаблон Visitor. Изучите этот шаблон по википедии.

Определите интерфейс IVisitor и реализуйте его в двух классах DimensionsVisitor и SurfaceAreaVisitor, для рассчёта размеров (ширина, высота) и площади поверхности фигур.

В класс Body добавьте абстрактный метод Accept(IVisitor visitor).

Автоматизированные тесты проверяют лишь базовые требования. Проверить, что вы всё сделали правильно можно самостоятельно так:

* В реализациях Visitor не должно быть ни одного приведения типов и ни одного if-а. Именно этой простотой решение с Visitor-ом лучше исходного с длинным if-else.

* Работа с каждой фигурой должна оказаться в отдельном методе. А значит даже если добавится новая фигура, будет меньше возможностей случайно внести ошибку в обработку старых фигур.

* Компилятор должен контролировать, что вы не забыли обработать ни одну из фигур: если вы забудете написать один из методов, программа даже не скомпилируется.

* В интерфейсе IVisitor, в классе Body и всех его подклассах не должно быть никакого упоминания площади поверхности, размеров или конкретных классов Visitor-ов. А значит при добавлении новых методов, эти классы не нужно будет трогать.

* Для добавления нового метода работы с фигурами, должно быть достаточно добавить новый класс Visitor-а.