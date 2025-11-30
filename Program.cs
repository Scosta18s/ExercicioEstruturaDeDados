namespace ExercicioEstruturaDeDados;

class Program
{
    static void Main(string[] args)
    {

        var listaPrincipal = new ListaEncadeada();

        Console.WriteLine("=== Adicionando 50 números ===");
        for (int i = 0; i < 50; i++)
        {
            Console.Write($"Digite o {i + 1}º número: ");
            int numero = int.Parse(Console.ReadLine()!);
            listaPrincipal.Adicionar(numero);
        }

        Console.WriteLine($"\nQuantidade de elementos após adicionar: {listaPrincipal.Quantidade}");

        Console.WriteLine("\n=== Removendo 25 números ===");
        for (int i = 0; i < 25; i++)
        {
            listaPrincipal.Remover();
        }
        Console.WriteLine($"Quantidade de elementos após remover: {listaPrincipal.Quantidade}");


        Console.WriteLine("\n=== Percentual de Pares e Ímpares ===");
        ImprimirPercentuais(listaPrincipal);


        Console.WriteLine("\n=== Ordenando a lista ===");
        OrdenarLista(listaPrincipal);

        Console.WriteLine("\nLista ordenada:");
        listaPrincipal.ParaCada(v => Console.Write($"{v} "));
        Console.WriteLine();
    }

    static void ImprimirPercentuais(ListaEncadeada lista)
    {
        int totalPares = 0;
        int totalImpares = 0;

        lista.ParaCada(valor =>
        {
            if (valor % 2 == 0)
                totalPares++;
            else
                totalImpares++;
        });

        int total = lista.Quantidade;

        if (total == 0)
        {
            Console.WriteLine("A lista está vazia.");
            return;
        }

        double percentualPares = (totalPares * 100.0) / total;
        double percentualImpares = (totalImpares * 100.0) / total;

        Console.WriteLine($"Percentual de números pares: {percentualPares:F2}%");
        Console.WriteLine($"Percentual de números ímpares: {percentualImpares:F2}%");
    }


    static void OrdenarLista(ListaEncadeada lista)
    {
        if (lista.NoInicio == null)
            return;

        bool houveTroca;
        do
        {
            houveTroca = false;
            var atual = lista.NoInicio;

            while (atual?.Proximo != null)
            {
                if (atual.Valor > atual.Proximo.Valor)
                {
                    int aux = atual.Valor;
                    atual.Valor = atual.Proximo.Valor;
                    atual.Proximo.Valor = aux;
                    houveTroca = true;
                }
                atual = atual.Proximo;
            }
        } while (houveTroca);
    }
}
