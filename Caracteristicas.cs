using System;
public class Caracteristicas{
    
    private int velocidad; //1 a 10
    private int destreza; //1 a 5
    private int magia; //1 a 10
    private int nivel; //1 a 10
    private int coraje; //1 a 10
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
    public int Magia
    {
        get => magia; 
        private set => magia = value;
    }//1 a 10
    public int Nivel
    {
        get => nivel; 
        private set => nivel = value;
    } //1 a 10
    public int Coraje 
    {
        get => coraje; 
        private set => coraje = value;
    } //1 a 10
    public int Salud
    {
        get => salud; 
        set => salud = value;
    } //100

    public Caracteristicas(int velocidad, int destreza, int magia, int nivel, int coraje){
        Velocidad = velocidad;
        Destreza = destreza;
        Magia = magia;
        Nivel = nivel;
        Coraje = coraje;
        Salud = 100;
    }
}