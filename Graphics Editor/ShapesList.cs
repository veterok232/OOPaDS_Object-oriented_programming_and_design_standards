//Модуль, реализующий хранение фигур в списке, а также функции Undo и Redo

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graphics_Editor
{
    public class ShapesList
    {
        public Dictionary<int, Shape> shapesList;       //Список текущих фигур
        private Dictionary<int, Shape> shapesListRedo;   //Список фигур, которые были отменены
        private int shapesNumber;                        //Количество текущих фигур
        private int shapesNumberRedo;                    //Количество отмененных фигур

        public ShapesList()
        {
            shapesList = new Dictionary<int, Shape>();
            shapesListRedo = new Dictionary<int, Shape>();
            shapesNumber = 0;
            shapesNumberRedo = 0;
        }

        //Добавление фигуры в список
        public void Add(Shape shape)
        {
            shapesList[++shapesNumber] = shape.Clone();
        }

        //Функция Undo
        public void Undo()
        {
            if (shapesNumber > 0)
            {
                shapesListRedo[++shapesNumberRedo] = shapesList[shapesNumber];
                shapesList.Remove(shapesNumber);
                shapesNumber--;
            }
        }

        //Функция Redo
        public void Redo()
        {
            if (shapesNumberRedo > 0)
            {
                shapesList[++shapesNumber] = shapesListRedo[shapesNumberRedo];
                shapesListRedo.Remove(shapesNumberRedo);
                shapesNumberRedo--;
            }
        }

        //Функция сброса списка Redo
        public void ResetRedo()
        {
            shapesListRedo.Clear();
            shapesNumberRedo = 0;
        }

        public void Clear()
        {
            shapesList.Clear();
            shapesListRedo.Clear();
        }

        //Отрисовка всего списка фигур
        public void Draw(Graphics g)
        {
            g.Clear(Color.White);

            foreach (KeyValuePair<int, Shape> pair in shapesList)
            {
                pair.Value.Draw(g);
            }            
        }
    }
}
