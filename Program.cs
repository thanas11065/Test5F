using System;
class Program
{
    static void Main(string[] args)
    {
        Tree<string> tree = new Tree<string>();
        
        string RootName = "Head";
        string Absent =  "";
        string Sipling = "";
        string General = "";
        string HeadName = Console.ReadLine();
        int Headamount = int.Parse(Console.ReadLine());
        int amount = 0;
        int Siplingamount = 0;
        tree.AddChild(-1,RootName);
        tree.AddChild(0,HeadName);
        Manage(ref amount,ref Headamount, ref Siplingamount,ref tree,ref General, ref Sipling);
        Absent = Console.ReadLine();  
    }
    static void Manage(ref int amount,ref int Headamount ,ref int Siplingamount, ref Tree<string> tree, ref string General, ref string Sipling)
    {
        int j = 1;
        while( j<=Headamount)
            {
                General = Console.ReadLine();
                tree.AddChild(j,General);
                amount = int.Parse(Console.ReadLine());
                 Lower(ref amount,ref Headamount ,ref Siplingamount,ref tree,ref General,ref Sipling);
                
            }      
    }
    static void Lower(ref int amount,ref int Headamount,ref int Siplingamount,ref Tree<string> tree,ref string General,ref string Sipling)
    {
        int i =1;
        while( i<= amount)
            {
                Sipling = Console.ReadLine();
                tree.AddSibling(i,Sipling);
                Siplingamount= int.Parse(Console.ReadLine());
                if(Siplingamount > 0) Manage(ref amount,ref Headamount ,ref Siplingamount, ref tree, ref General, ref Sipling);
                
            }
    }
}