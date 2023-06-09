using ProjektZaverecny2Verze1;

Vlak vlak = new Vlak();
Vlak vlak2 = new Vlak();    

vlak.ZadejNazevVlaku();
vlak.ZadavejSouradnice();
vlak.ZadejCasOdjezdu();
vlak.ZadejRychlost();

vlak2.ZadejNazevVlaku();
vlak2.ZadavejSouradnice();
vlak2.ZadejCasOdjezdu();
vlak2.ZadejRychlost();

Console.Clear();

vlak.VypocitejDelkuTrasy();
vlak.VypocitejCasSouradnice();
vlak.VypisSouradniceVlaku();
vlak.VypisCasSouradnice();
Console.WriteLine(vlak.VratDelkuTrasy());
Console.WriteLine(vlak.VratCasOdjezdu());
Console.WriteLine(vlak.VratRychlost());

vlak2.VypocitejDelkuTrasy();
vlak2.VypocitejCasSouradnice();
vlak2.VypisSouradniceVlaku();
vlak2.VypisCasSouradnice();
Console.WriteLine(vlak2.VratDelkuTrasy());
Console.WriteLine(vlak2.VratCasOdjezdu());
Console.WriteLine(vlak2.VratRychlost());

vlak.SrovnejCasySouradnice(vlak2);












