﻿// See https://aka.ms/new-console-template for more information
using MazeGame;

Console.WriteLine("Hello, World!");

IdentifiableObject id = new IdentifiableObject(new string[] {"ID1", "iD2", "Id3", "id4", "id1" });
IdentifiableObject id2 = new IdentifiableObject(new string[0] { });

Console.WriteLine(id.FirstId);

if(id2.FirstId == "")
{
    Console.WriteLine("id2 returned an empty string");
}
