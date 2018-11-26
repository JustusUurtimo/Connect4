using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class Harkkatyo : PhysicsGame
{
    private Ruutu[] Sarakkeet;

    public override void Begin()
    {
        this.Sarakkeet = new Ruutu[7];
        // Painovoima, jos tarvii myöhemmin
        Gravity = new Vector(0.0, -800.0);

        //tuodaan kentta peliin
        LuoKentta();

        //vuorot??
        IsMouseVisible = true;
       

        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, LuoNappulaP, "ruutu", Mouse.PositionOnWorld);



       
        







        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    // kentan luominen
    void LuoKentta()
    {
        //kaksiulotteinen taulukko s=sarakkeet r=rivit
        for(int s = 0; s < 6; s++)
        {
            for(int r = 0; r < 7; r++)
            {
                if(s == 0)
                {
                    this.Sarakkeet[r] = new Ruutu(100, 100);
                }
            }
        }

        

    }
    //maan luominen
    void LuoMaata(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject maa = PhysicsObject.CreateStaticObject(100, 10);
        maa.Color = Color.Blue;
        maa.Shape = Shape.Rectangle;
        maa.Position = paikka;
        Add(maa);
    }
    //seinien luominen
    void LuoSeina(double leveys, double korkeus)
    {
        PhysicsObject seina = PhysicsObject.CreateStaticObject(10, 100);
        seina.Color = Color.Blue;
        seina.Shape = Shape.Rectangle;
        
        Add(seina);
    }

    //Pelinappulan luonti haluttuun paikkaan.
    void LuoNappulaP(Vector paikka)
    {
        PhysicsObject nappula = new PhysicsObject(100, 100);
        nappula.Shape = Shape.Rectangle;
        nappula.Color = Color.Red;
        nappula.Position = Mouse.PositionOnWorld;
        MessageDisplay.Add("" + nappula.Position.X + ", " + nappula.Position.Y);
        Add(nappula);

    }
    
    //pitäs luoda tyhjät paikat olioiksi kenttään

    class Ruutu : PhysicsObject
    {
        
        public bool varattu { get; set; }
        public Color vari { get; set; }
        

        public Ruutu(double leveys, double korkeus)
            : base(100, 100)
        {
           
            varattu = false;
            vari = Color.Red;
           
            
        }
    }
   /* private void HiirenPainallus(Vector paikka)
    {
        int painettuKohta = YakselinPaikka(paikka);
        Console.WriteLine(painettuKohta);
    }*/
    /*
    private int YakselinPaikka(Vector paikka)
    {
        for(int i = 0; i < ruudukkoY.Length; i++)
        {
                if (paikka.X >= ruudukkoY[i].X && paikka.Y >= ruudukkoY[i].Y)
                {
                    if (paikka.X <= ruudukkoY[i].X + ruudukkoY[i].Width && paikka.Y <= ruudukkoY[i].Y + ruudukkoY[i].Height)
                    {
                        return i;
                    }
            }
            
           
        }
        return - 1;
    }*/
    /*public PhysicsObject ruutu2()
    {
        PhysicsObject ruutu = new PhysicsObject(40, 40, Shape.Rectangle);
        bool olemassa = false;
        Color vari = Color.Red;
        return ruutu;
    }*/
}
   

    



    




