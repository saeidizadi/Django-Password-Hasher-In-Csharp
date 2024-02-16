using Application;

// Look Here Is The One Test From PBKDF2-SHA256 Django
Console.WriteLine("Please Enter Your Password : ");
string password = Console.ReadLine();

string hashedPassword = password.GeneratePbkdf2Sha256PassDjango();
Console.WriteLine($"Hashed Password : {hashedPassword}");

Console.ReadKey();

// My Site : saeidizadi.ir;