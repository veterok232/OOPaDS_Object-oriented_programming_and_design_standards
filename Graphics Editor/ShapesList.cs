//Модуль, реализующий хранение фигур в списке, а также функции Undo и Redo

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graphics_Editor
{
    public static class ShapesList
    {
        private static Dictionary<int, Shape> shapesList;       //Список текущих фигур
        private static Dictionary<int, Shape> shapesListRedo;   //Список фигур, которые были отменены
        private static int shapesNumber;                        //Количество текущих фигур
        private static int shapesNumberRedo;                    //Количество отмененных фигур

        static ShapesList()
        {
            shapesList = new Dictionary<int, Shape>();
            shapesListRedo = new Dictionary<int, Shape>();
            shapesNumber = 0;
            shapesNumberRedo = 0;
        }

        //Добавление фигуры в список
        public static void Add(Shape shape)
        {
            shapesList[++shapesNumber] = shape.Clone();
        }

        //Функция Undo
        public static void Undo()
        {
            if (shapesNumber > 0)
            {
                shapesListRedo[++shapesNumberRedo] = shapesList[shapesNumber];
                shapesList.Remove(shapesNumber);
                shapesNumber--;
            }
        }

        //Функция Redo
        public static void Redo()
        {
            if (shapesNumberRedo > 0)
            {
                shapesList[++shapesNumber] = shapesListRedo[shapesNumberRedo];
                shapesListRedo.Remove(shapesNumberRedo);
                shapesNumberRedo--;
            }
        }

        //Функция сброса списка Redo
        public static void ResetRedo()
        {
            shapesListRedo.Clear();
            shapesNumberRedo = 0;
        }

        //Отрисовка всего списка фигур
        public static void Draw(Graphics g)
        {
            g.Clear(Color.White);

            foreach (KeyValuePair<int, Shape> pair in shapesList)
            {
                pair.Value.Draw(g);
            }            
        }
    }
}
