public class ListaEncadeada
{
    public void AdicionarNoInicio(int valor)
    {
        var novoNo = new No { Valor = valor };

        novoNo.Proximo = inicio;

        if (inicio == null)
            fim = novoNo;

        inicio = novoNo;
    }

    public void AdicionarNoFinal(int valor)
    {
        var novoNo = new No { Valor = valor };

        if (fim == null)
        {
            inicio = fim = novoNo;
            return;
        }

        fim.Proximo = novoNo;
        fim = novoNo;
    }

    public void RemoverNoInicio()
    {
        if (inicio == null)
            throw new Exception("A lista está vazia");

        inicio = inicio.Proximo;

        if (inicio == null)
            fim = null;
    }

    public void RemoverNoFinal()
    {
        if (inicio == null)
            throw new Exception("A lista está vazia");

        if (inicio.Proximo == null)
        {
            inicio = fim = null;
            return;
        }

        var penultimo = inicio;

        while (penultimo?.Proximo?.Proximo != null)
            penultimo = penultimo.Proximo;

        if (penultimo != null)
        {
            penultimo.Proximo = null;
            fim = penultimo;
        }
    }

    public void ParaCada(Action<int> processar)
    {
        var atual = inicio;

        while (atual != null)
        {
            processar(atual.Valor);
            atual = atual.Proximo;
        }
    }

    public bool SaoIguais(ListaEncadeada outraLista)
    {
        var no1 = this.inicio;
        var no2 = outraLista.inicio;

        while (no1 != null && no2 != null)
        {
            if (no1.Valor != no2.Valor)
                return false;

            no1 = no1.Proximo;
            no2 = no2.Proximo;
        }

        return no1 == null && no2 == null;
    }

    private No? inicio = null;
    private No? fim = null;
}
