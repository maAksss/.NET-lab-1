using System.Text;

abstract class Body
{
    public string TypeName() // для ранього 
    {
        return "Тіло";
    }

    public abstract double Area();
    public abstract double Volume();

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Body other) return false;

        return this.Volume() == other.Volume();
    }

    public override int GetHashCode()
    {
        return Volume().GetHashCode();
    }
}

//Куля, Паралелепіпед, Тетраедр. 
class kul : Body
{
    double r;

    public kul(double radius)
    {
        r = radius;
    }

    public override double Area()
    {
        return 4 * Math.PI * r * r;
    }

    public override double Volume()
    {
        return 4.0 / 3.0 * Math.PI * r * r * r;
    }
}
class paralepiped : Body
{
    double a, b, c;

    public paralepiped(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double Area()
    {
        return 2 * (a * b + a * c + b * c);
    }

    public override double Volume()
    {
        return a * b * c;
    }
}
class Tetra : Body
{
    double a;

    public Tetra(double edge)
    {
        a = edge;
    }

    public override double Area()
    {
        return Math.Sqrt(3) * a * a;
    }

    public override double Volume()
    {
        return a * a * a / (6 * Math.Sqrt(2));
    }
}

class Program
{
    static void Main(string[] args)
    {Console.OutputEncoding = Encoding.UTF8;

        Body[] bodies = new Body[]
        {
            new kul(3),
            new paralepiped(2, 4, 6),
            new Tetra(5),
            new paralepiped(8, 2, 3)
        };

        foreach (Body body in bodies)
        {
            Console.WriteLine($"Фігура: {body.GetType().Name}");
            Console.WriteLine($"Площа поверхні: {body.Area():F2}");
            Console.WriteLine($"Обʼєм: {body.Volume():F2}");
            Console.WriteLine(new string('-', 30));
        }

        Console.WriteLine("\n--- Перевірка методу Equals ---");

        // 1. Порівняння паралелепіпедів з однаковим об'ємом
        Body p1 = bodies[1]; // 2*4*6 = 48
        Body p2 = bodies[3]; // 8*2*3 = 48
        Console.WriteLine($"Паралелепіпед {p1.Volume():F2} == Паралелепіпед {p2.Volume():F2}?  Відповідь: {p1.Equals(p2)}");

        // 2. Порівняння кулі та тетраедра
        Body k = bodies[0];
        Body t = bodies[2];
        Console.WriteLine($"Куля {k.Volume():F2} == Тетраедр {t.Volume():F2}?  Відповідь: {k.Equals(t)}");

        // 3. Порівняння об'єкта самого з собою
        Console.WriteLine($"Фігура {p1.GetType().Name} == сама собою?  Відповідь: {p1.Equals(p1)}");

        // 4. Перевірка на null
        Console.WriteLine($"Фігура == null?  Відповідь: {p1.Equals(null)}");

    }
}