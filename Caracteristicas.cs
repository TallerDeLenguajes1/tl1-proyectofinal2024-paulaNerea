using System;
public class Caracteristicas{
    
    private int velocidad; //1 a 10
    private int destreza; //1 a 5
    private int fuerza; //1 a 10
    private int nivel; //1 a 10
    private int armadura; //1 a 10
    private int salud; //100

    public int Velocidad 
    {
        get => velocidad; 
        private set => velocidad = value;
    } //1 a 10
    public int Destreza 
    {
        get => destreza; 
        private set => destreza = value;
    } //1 a 5
    public int Fuerza
    {
        get => fuerza; 
        private set => fuerza = value;
    }//1 a 10
    public int Nivel
    {
        get => nivel; 
        private set => nivel = value;
    } //1 a 10
    public int Armadura 
    {
        get => armadura; 
        private set => armadura = value;
    } //1 a 10
    public int Salud
    {
        get => salud; 
        private set => salud = value;
    } //100

    public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura){
        Velocidad = velocidad;
        Destreza = destreza;
        Fuerza = fuerza;
        Nivel = nivel;
        Armadura = armadura;
        Salud = 100;
    }
}