using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class Harkkatyo : PhysicsGame
{
    public char[,] kenttani =
    {
        {'#', '.', '#', '.', '#', '.', '#', '.', '#',  '.', '#', '.', '#', '.', '#'},
        {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'},
        {'#', '.', '#', '.', '#', '.', '#', '.', '#',  '.', '#', '.', '#', '.', '#'},
        {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'},
        {'#', '.', '#', '.', '#', '.', '#', '.', '#',  '.', '#', '.', '#', '.', '#'},
        {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'},
        {'#', '.', '#', '.', '#', '.', '#', '.', '#',  '.', '#', '.', '#', '.', '#'},
        {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'},
        {'#', '.', '#', '.', '#', '.', '#', '.', '#',  '.', '#', '.', '#', '.', '#'},
        {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'},
        {'#', '.', '#', '.', '#', '.', '#', '.', '#',  '.', '#', '.', '#', '.', '#'},
        {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'},
        {'#', '.', '#', '.', '#', '.', '#', '.', '#',  '.', '#', '.', '#', '.', '#'},
        {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'},
    };

    public override void Begin()
    {
        // Painovoima, jos tarvii myöhemmin
        Gravity = new Vector(0.0, -800.0);

        //tuodaan kentta peliin
        LuoKentta();

        //vuorot??
        int vuoro = 1;


        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, LuoNappulaP, "ruutu", Mouse.PositionOnScreen);

       

        








        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    // kentan luominen
    void LuoKentta()
    {
        TileMap kentta = new TileMap(kenttani);
        kentta.SetTileMethod('#', LuoSeina);
        kentta.SetTileMethod('-', LuoMaata);
        //tyhjät pitää saada olioiksi
        kentta['.'] = ruutu2;

        kentta.Execute();

    }
    //maan luominen
    void LuoMaata(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject maa = PhysicsObject.CreateStaticObject(leveys, 10);
        maa.Color = Color.Blue;
        maa.Shape = Shape.Rectangle;
        maa.Position = paikka;
        Add(maa);
    }
    //seinien luominen
    void LuoSeina(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject seina = PhysicsObject.CreateStaticObject(10, 100);
        seina.Color = Color.Blue;
        seina.Shape = Shape.Rectangle;
        seina.Position = paikka;
        Add(seina);
    }

    //Pelinappulan luonti haluttuun paikkaan.
    void LuoNappulaP(Vector paikka)
    {
        PhysicsObject nappula = new PhysicsObject(60, 60);
        nappula.Shape = Shape.Circle;
        nappula.Color = Color.Red;
        nappula.Position = Mouse.PositionOnWorld;
        MessageDisplay.Add("" + paikka.X + ", " + paikka.Y);
        Add(nappula);

    }
    
    //pitäs luoda tyhjät paikat olioiksi kenttään

    /*class ruutu : PhysicsObject
    {
        
        public bool varattu { get; set; }
        public Color vari { get; set; }
        

        public ruutu(double leveys, double korkeus)
            : base(leveys, korkeus)
        {
           
            varattu = false;
            vari = Color.Red;
           
            
        }
    }*/
    public PhysicsObject ruutu2()
    {
        PhysicsObject ruutu = new PhysicsObject(40, 40, Shape.Rectangle);
        bool olemassa = false;
        Color vari = Color.Red;
        return ruutu;
    }
}
   

    



    




