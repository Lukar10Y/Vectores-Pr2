using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectoresTarea
{
    class Punto
    {
        private float x;
        private float y;
        public Punto()
        {

        }
        public Punto(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public void SetX(float _x)
        {
            x = _x;
        }
        public void SetY(float _y)
        {
            y = _y;
        }
        public float GetX()
        {
            return x;
        }
        public float GetY()
        {
            return y;
        }

        ~Punto()
        {
            Console.WriteLine($"\nMe estoy destruyendo ({x},{y})");
            //Console.ReadLine();
        }
    }

    class Vector
    {
        Punto origen;
        Punto fin;
        double magnitud;

        public Vector()
        {
            origen = new Punto(0, 0);
            fin = new Punto(1, 1);
            calcular_magnitud();
        }
        public Vector(Punto _origen, Punto _fin)
        {
            origen = new Punto(_origen.GetX(), _origen.GetY());
            fin = new Punto(_fin.GetX(), _fin.GetY());
            calcular_magnitud();
        }
        public Vector(float x_origen, float y_origen, float x_fin, float y_fin)
        {
            origen = new Punto(x_origen, y_origen);
            fin = new Punto(x_fin, y_fin);
            calcular_magnitud();
        }
        private void calcular_magnitud()
        {
            magnitud = Math.Sqrt(Math.Pow((fin.GetX() - origen.GetX()), 2) + Math.Pow((fin.GetY() - origen.GetY()), 2));
        }
        public double get_magnitud()
        {
            return magnitud;
        }

        public void set_origen(Punto _origen)
        {
            origen = new Punto(_origen.GetX(), _origen.GetY());
            calcular_magnitud();
        }
        public void set_origen(float x, float y)
        {
            origen = new Punto(x, y);
            calcular_magnitud();
        }

        public string mostrar_info()
        {
            return $"Origen X: {origen.GetX()}, Origen Y: {origen.GetY()}, Fin X: {fin.GetX()}, Fin Y: {fin.GetY()}\n";
        }

        //TAREA PARTE 1 ***************************************
        public void set_fin(Punto _fin)
        {
            origen = new Punto(_fin.GetX(), _fin.GetY());
            calcular_magnitud();
        }
        public void set_fin(float x, float y)
        {
            fin = new Punto(x, y);
            calcular_magnitud();
        }

        //*****************************************************

        public static Vector operator +(Vector sumando1, Vector sumando2)
        {
            Punto nuevo_origen = new Punto(sumando1.origen.GetX() + sumando2.origen.GetX(),
                                           sumando1.origen.GetY() + sumando2.origen.GetY());

            Punto nuevo_fin = new Punto(sumando1.fin.GetX() + sumando2.fin.GetX(),
                                        sumando1.fin.GetY() + sumando2.fin.GetY());

            return new Vector(nuevo_origen, nuevo_fin);
        }

        //TAREA PARTE 2 ***************************************
        public static Vector operator -(Vector restando1, Vector restando2)
        {
            Punto nuevo_origen = new Punto(restando1.origen.GetX() - restando2.origen.GetX(),
                                           restando1.origen.GetY() - restando2.origen.GetY());

            Punto nuevo_fin = new Punto(restando1.fin.GetX() - restando2.fin.GetX(),
                                        restando1.fin.GetY() - restando2.fin.GetY());

            return new Vector(nuevo_origen, nuevo_fin);
        }

        //*****************************************************

        //TAREA PARTE 3 ***************************************
        public static Vector operator *(Vector vector, double escalar)
        {
            string convert = escalar.ToString();
            float _escalar = float.Parse(convert);

            Punto nuevo_origen = new Punto(vector.origen.GetX() * _escalar,
                                           vector.origen.GetY() * _escalar);

            Punto nuevo_fin = new Punto(vector.fin.GetX() * _escalar,
                                        vector.fin.GetY() * _escalar);

            return new Vector(nuevo_origen, nuevo_fin);
        }

        //*****************************************************

        //TAREA PARTE 4 ***************************************
        public static float operator *(Vector multiplicando1, Vector multiplicando2)
        {
            float componenteX_1 = multiplicando1.fin.GetX() - multiplicando1.origen.GetX();
            float componenteY_1 = multiplicando1.fin.GetY() - multiplicando1.origen.GetY();
            float componenteX_2 = multiplicando2.fin.GetX() - multiplicando2.origen.GetX();
            float componenteY_2 = multiplicando2.fin.GetY() - multiplicando2.origen.GetY();

            return (componenteX_1 * componenteX_2) + (componenteY_1 * componenteY_2);
        }
        //*****************************************************
    }

    class Program
    {
        static void Main()
        {
            /*
                        Punto my_punto = new Punto();
                        Punto my_punto_2 = new Punto(6,8);
                        my_punto.SetX(10);
                        my_punto.SetY(5);
                        my_punto_2.SetX(20);
                        my_punto_2.SetY(45);
                        Console.WriteLine($"Mi valor en x es: {my_punto.GetX()}\nMi valor en y es: {my_punto.GetY()}");
                        Console.WriteLine("Mi valor en x es: {0}\nMi valor en y es: {1}", my_punto_2.GetX(), my_punto_2.GetY());
            */

            Vector my_vector = new Vector(0, 0, 4, 3);
            Vector my_vector_2 = new Vector(0, 0, 4, 3);

            my_vector.set_fin(5, 8);

            Vector my_vector_3 = my_vector + my_vector_2;
            my_vector += my_vector_2;

            Vector my_vector_4 = new Vector(0, 0, 1, 3);
            Vector my_vector_5 = new Vector(0, 0, 4, 1);

            Vector my_vector_6 = my_vector_4 - my_vector_5;

            Console.WriteLine(my_vector_4.mostrar_info());
            Console.WriteLine(my_vector_5.mostrar_info());
            Console.WriteLine(my_vector_6.mostrar_info());

            Vector my_vector_7 = new Vector(0, 0, 1, 3);

            Console.WriteLine(my_vector_7.mostrar_info());

            my_vector_7 = my_vector_7 * 2.5;
            my_vector_7 *= 2.5;

            Console.WriteLine(my_vector_7.mostrar_info());

            Vector my_vector_8 = new Vector(3, 1, 5, 4);
            Vector my_vector_9 = new Vector(3, 1, 5, 4);

            float puntoProducto = my_vector_8 * my_vector_9;
            Console.WriteLine($"Multiplicacion Punto: {puntoProducto}\n");

            Console.WriteLine($"Mi magnitud es de: {my_vector_3.get_magnitud()}");
            Console.WriteLine($"Mi magnitud es de: {my_vector_6.get_magnitud()}");
            Console.ReadLine();
        }
    }
}
