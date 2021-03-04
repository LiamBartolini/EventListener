using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter(10); // Imposto il valore da raggiungere
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("premi 'a' per aumentare il totale...");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("aggiunto uno al totale");
                c.Add(1);
            }
        }

        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("Obbiettivo raggiunto"); // Output
            Environment.Exit(0); // Fa terminare il programma con il codice '0'
        }
    }

    class Counter
    {
        private int threshold;
        private int total;

        // Costruttore a cui passo il valore da raggiungere
        public Counter(int passedThreshold) => threshold = passedThreshold;

        // Metodo per incrementare il valore di a
        public void Add(int x)
        {
            total += x; // Incrementa il totale
            if (total >= threshold) // Se il totale è >= dell'obbiettivo da raggiungere
                OnThresholdReached(EventArgs.Empty); // Richiama il metodo OnThresholdReached() e gli passa l'argomento EventArgs.Empty
        }

        // Metodo di quando si raggiunge l'obbiettivo
        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached; // Oggetto EventHandler gli assegna il valore dell'Event della classe
            if (handler != null) // Se l'Handler è diverso da null
                handler(this, e); // Gli passa l'istanza, e gli eventi
        }

        public event EventHandler ThresholdReached; // EvenetHandler
    }
}
