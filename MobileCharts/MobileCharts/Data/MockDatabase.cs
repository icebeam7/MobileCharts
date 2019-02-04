using System.Collections.Generic;
using System.Threading.Tasks;

using MobileCharts.Models;
using static MobileCharts.Helpers.MathHelper;

namespace MobileCharts.Data
{
    public static class MockDatabase
    {
        public static async Task<List<Ventas>> ObtenerVentas()
        {
            var li = 1000;
            var ls = 3500;

            return new List<Ventas>()
            {
                new Ventas() { Mes = "Enero", Monto = GetRandomValue(li, ls)},
                new Ventas() { Mes = "Febrero", Monto = GetRandomValue(li, ls)},
                new Ventas() { Mes = "Marzo", Monto = GetRandomValue(li, ls)},
                new Ventas() { Mes = "Abril", Monto = GetRandomValue(li, ls)},
                new Ventas() { Mes = "Mayo", Monto = GetRandomValue(li, ls)},
            };
        }

        public static async Task<List<Pokemon>> ObtenerPokemons()
        {
            return new List<Pokemon>()
            {
                new Pokemon() { Nombre = "Articuno", Ataque = 295, Defensa = 328, Salud = 384, Velocidad = 295 },
                new Pokemon() { Nombre = "Blastoise", Ataque = 291, Defensa = 328, Salud = 362, Velocidad = 280 },
            };
        }

        public static async Task<List<Movimiento>> ObtenerMovimientos()
        {
            var movimientos = new List<Movimiento>();

            for (int x = -2; x < 3; x++)
                movimientos.Add(new Movimiento() { X = x, Y = f(x) });

            return movimientos;
        }

        public static async Task<List<Memoria>> ObtenerUsoMemoria()
        {
            var usoMemoria = new List<Memoria>();

            for (int i = 0; i < 6; i++)
                usoMemoria.Add(new Memoria()
                {
                    Minuto = i * 10,
                    PorcentajeUso = GetRandomValue(0, 100)
                });

            return usoMemoria;
        }

        public static async Task<List<Divisa>> ObtenerVariacionDivisas()
        {
            var variacionDivisas = new List<Divisa>();

            for (int i = 0; i < 10; i++)
            {
                var values = new List<double>()
                {
                    GetRandomValue(10, 20),
                    GetRandomValue(10, 20),
                    GetRandomValue(10, 20),
                    GetRandomValue(10, 20)
                };
                values.Sort();

                var normal = GetRandomBool();

                variacionDivisas.Add(new Divisa()
                {
                    Hora = i + 8,
                    Maximo = values[3],
                    Minimo = values[0],
                    Apertura = normal ? values[1] : values[2],
                    Cierre = normal ? values[2] : values[1]
                });
            }

            return variacionDivisas;
        }

        public static async Task<List<Persona>> ObtenerDatosPersonas()
        {
            var datosPersona = new List<Persona>();

            for (int i = 0; i < 50; i++)
            {
                datosPersona.Add(new Persona()
                {
                    Altura = GetRandomValue(130, 190) / 100.0,
                    Peso = GetRandomValue(130, 190) / 100.0,
                    Edad = (int)GetRandomValue(5, 15),
                    Genero = GetRandomBool()
                });
            }

            return datosPersona;
        }

        public static async Task<double[,]> ObtenerPuntosRastrigin(double x0, double x1, double y0, double y1, int n)
        {
            var xx = CreateVector(x0, x1, n);
            var yy = CreateVector(y0, y1, n);
            var nn = n + 1;

            var datos = new double[nn, nn];

            for (int i = 0; i < nn; i++)
                for (int j = 0; j < nn; j++)
                    datos[i, j] = Rastrigin(xx[i], yy[j]);

            return datos;
        }
    }
}
