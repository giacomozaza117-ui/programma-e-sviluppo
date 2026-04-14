using System;

class Palestra
{
    // Il metodo Main è statico perché è il punto di ingresso del programma.
    // Anche se gli altri metodi NON sono statici,
    // Main può creare un oggetto per usarli.
    public static void Main()
    {
        // Imposta la codifica della console per supportare caratteri speciali come "€"
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Creiamo un'istanza (oggetto) della classe Palestra.
        // I metodi NON statici si possono usare solo tramite un oggetto.
        Palestra p = new Palestra();

        // Usiamo il metodo pubblico LeggiNumero per far inserire i mesi all'utente.
        int mesi = p.LeggiNumero("Inserire numero di mesi:");

        // Lettura del sesso (M/F)
        Console.WriteLine("Inserire sesso (M/F):");
        string sesso = Console.ReadLine().ToUpper(); // .ToUpper() = converte in maiuscolo

        // Lettura della fascia oraria (F1/F2)
        Console.WriteLine("Inserire fascia oraria (F1/F2):");
        string fascia = Console.ReadLine().ToUpper();

        // Calcolo del prezzo mensile in base ai dati inseriti
        // ➜ Metodo NON statico, quindi si usa tramite l'oggetto p
        double prezzoMensile = p.GetPrezzoMensile(sesso, fascia);

        // Calcolo del costo totale prima dello sconto
        double costoTotale = prezzoMensile * mesi;

        // Calcolo dello sconto tramite un metodo ad hoc
        double sconto = p.CalcolaSconto(mesi, costoTotale);

        // Calcolo del costo finale sottraendo lo sconto
        double costoFinale = costoTotale - sconto;

        // Stampa del risultato
        Console.WriteLine($"Il costo finale dell'abbonamento è: {costoFinale} euro");
    }

    // ---------------------------------------------------------
    // METODO PUBBLICO: determina il prezzo mensile dell'abbonamento
    // in base al sesso dell'utente e alla fascia oraria scelta.
    // ---------------------------------------------------------
    public double GetPrezzoMensile(string sesso, string fascia)
    {
        // Se l'utente è uomo
        if (sesso == "M")
        {
            if (fascia == "F1") return 10;  // Prezzo per uomini fascia 1
            if (fascia == "F2") return 15;  // Prezzo per uomini fascia 2
        }
        // Se l'utente è donna
        else if (sesso == "F")
        {
            if (fascia == "F1") return 7;   // Prezzo per donne fascia 1
            if (fascia == "F2") return 11;  // Prezzo per donne fascia 2
        }

        // Se arriva qui → input non valido
        Console.WriteLine("Errore: combinazione sesso/fascia non valida.");
        return 0; // 0 per indicare errore
    }

    // ---------------------------------------------------------
    // METODO PUBBLICO: calcola lo sconto sul costo totale
    // in base al numero di mesi dell'abbonamento.
    // ---------------------------------------------------------
    public double CalcolaSconto(int mesi, double costoTotale)
    {
        // Sconto maggiore per più mesi
        if (mesi >= 6)
            return costoTotale * 0.25; // Sconto 25%

        if (mesi >= 3)
            return costoTotale * 0.15; // Sconto 15%

        // Nessuno sconto sotto i 3 mesi
        return 0;
    }

    // ---------------------------------------------------------
    // METODO PUBBLICO: legge un numero da tastiera e assicura
    // che l'utente inserisca un valore valido (int).
    // ---------------------------------------------------------
    public int LeggiNumero(string messaggio)
    {
        int valore;

        // Mostra il messaggio passato come parametro
        Console.WriteLine(messaggio);

        // Continua a chiedere finché l'utente non inserisce un numero valido
        while (!int.TryParse(Console.ReadLine(), out valore))
        {
            // int.TryParse verifica se il testo inserito è un numero intero
            // Se NON lo è, si entra qui
            Console.WriteLine("Valore non valido. Inserire un numero:");
        }

        // Restituisce il numero corretto
        return valore;
    }
}