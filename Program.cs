using System.Collections.Generic;
int elegirMenu = 0, curso = 0, cantEstudiantes = 0, sumaTotalDinero = 0;
Dictionary<int,int> dicGuitaCursos = new Dictionary<int, int>();
while(elegirMenu != 3)
{
menu();
elegirMenu = ingresarInt("");
switch(elegirMenu)
{
    case 1:
    sumaTotalDinero = cantCursosYestudiantes(ref curso, ref cantEstudiantes);
    dicGuitaCursos.Add(curso, sumaTotalDinero);
    break;
    case 2:
    estadisticas(dicGuitaCursos);
    break;
    case 3:
    Environment.Exit(elegirMenu);
    break;
}
}
static int ingresarInt(string msj)
{
    int devolver;
    Console.Write(msj);
    devolver = int.Parse(Console.ReadLine());
    return devolver;
}
static void menu()
{
    Console.WriteLine("1 Si desea ingresar los importes de un curso ");
    Console.WriteLine("2 Si desea ver las estadisticas");
    Console.WriteLine("3 Si desea salir");
}
static int cantCursosYestudiantes(ref int curso, ref int cantEstudiantes)
{   
    int sumaTotalDinero = 0;
    curso = ingresarInt("Ingrese numero del curso: ");
    cantEstudiantes = ingresarInt("Ingrese la cantidad de estudiantes: ");
    int[] cantDineroPorEstudiante = new int[cantEstudiantes];
    for (int i = 0; i < cantEstudiantes; i++)
    {
        while(cantDineroPorEstudiante[i] <= 0)
        {
            cantDineroPorEstudiante[i] = ingresarInt("Ingrese la cantidad de dinero que desea ingresar el alumno " + (i + 1) + ": ");
        }
        sumaTotalDinero = sumaTotalDinero + cantDineroPorEstudiante[i];
    }
    return sumaTotalDinero;
}
static void estadisticas(Dictionary<int,int> dicGuitaCursos)
{
    int cursoMasCotizado = 0, sumaDeTodosLosCursos = 0, count = 0;
    foreach (int valor in dicGuitaCursos.Values)
    {
        cursoMasCotizado = valor;
        if(valor > cursoMasCotizado) cursoMasCotizado = valor;
        sumaDeTodosLosCursos = sumaDeTodosLosCursos + valor;
        count++;
    }
    Console.WriteLine("El curso que mas plata puso es el " + cursoMasCotizado); //CHECKEAR ESTA ESTADISTICA PQ NO SE COMO SACAR LA KEY DEL DICCIONARIO
    Console.WriteLine("El promedio de plata entre todos los cursos es de " + sumaDeTodosLosCursos/count + "$");
    Console.WriteLine("La recaudación total es de " + sumaDeTodosLosCursos + "$");
    Console.WriteLine("La cantidad de cursos que participan son " + count + " cursos");
}