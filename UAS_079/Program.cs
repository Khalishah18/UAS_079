using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_079
{
    class Node
    {
        public int nobuku, thnterbit;
        public string judbuku, nmpengarang;
        public Node next;
    }
    class List
    {
        Node START;

        public List()
        {
            START = null;
        }

        
        public void addNode()
        {
            int nobuku, thnterbit;
            string judbuku, nmpengarang;

            Console.Write("\nMasukkan Nomor Buku: ");
            nobuku = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Judul Buku Yang Dicari: ");
            judbuku = Console.ReadLine();
            Console.WriteLine("\nMasukkan Nama Pengarang Buku: ");
            nmpengarang = Console.ReadLine();
            Console.Write("\nMasukkan Tahun Terbit Buku: ");
            thnterbit = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();
            newnode.nobuku = nobuku;
            newnode.judbuku = judbuku;
            newnode.nmpengarang = nmpengarang;
            newnode.thnterbit = thnterbit;

            if (START == null || thnterbit <= START.thnterbit)
            {
                if ((START != null) && (thnterbit <= START.thnterbit))
                {
                    Console.WriteLine("\n BUKU TIDAK TERSEDIA ");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;


            while ((current != null) && (thnterbit >= current.thnterbit))
            {
                if (thnterbit == current.thnterbit)
                {
                    Console.WriteLine("\n BUKU TIDAK TERSEDIA \n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;

        }
        public bool SearchBook()
        {
            Console.Write("Masukkan Tahun Terbit Yang Akan Dicari: ");
            int thn = Convert.ToInt32(Console.ReadLine());

            Node previous, currentNode;
            previous = START;
            currentNode = START;

            while (currentNode != null)
            {
                if (thn == currentNode.thnterbit)
                {
                    Console.WriteLine("\nNo Buku: " + currentNode.nobuku + "\n" + "Judul Buku: " + currentNode.judbuku + "\n" +
                        "Nama Pengarang: " + currentNode.nmpengarang + "\n" + "Tahun Terbit: " + currentNode.thnterbit + "\n");
                }
                previous = currentNode;
                currentNode = currentNode.next;
            }
            if (currentNode == null)
                return (false);
            else
                return (true);
        }
        public bool Search(int thnterbit, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (thnterbit != current.thnterbit))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);

        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nBUKU TIDAK DITEMUKAN\n");
            else
            {
                Console.WriteLine("\nBuku Yang Tersedia Saat Ini: \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write("\nNo Buku: " + currentNode.nobuku + "\n" + "Judul Buku: " + currentNode.judbuku + "\n" +
                        "Nama Pengarang: " + currentNode.nmpengarang + "\n" + "Tahun Terbit: " + currentNode.thnterbit + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("Pilihan Menu Daftar Buku Perpustakaan");
                    Console.WriteLine("=======================================");
                    Console.WriteLine("1. Masukkan Data Buku : ");
                    Console.WriteLine("2. Mengurutkan Data Buku : ");
                    Console.WriteLine("3. Menampilkan Data Buku : ");
                    Console.WriteLine("4. Mencari Tahun Buku yang dicari : ");
                    Console.WriteLine("5. KELUAR");
                    Console.Write("\nMasukkan Pilihan Anda  (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                Console.WriteLine("");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nBUKU TIDAK DITEMUKAN");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan Tahun Terbit Yang Akan Dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nBUKU TIDAK DITEMUKAN.");
                                else
                                {
                                    Console.WriteLine("\nBUKU TERSEDIA");
                                    Console.WriteLine("======================================");
                                    Console.WriteLine("\nNomor Buku: " + current.nobuku);
                                    Console.WriteLine("\nJudul Buku: " + current.judbuku);
                                    Console.WriteLine("\nNama Pengarang: " + current.nmpengarang);
                                    Console.WriteLine("\nTahun Terbit: " + current.thnterbit);
                                    Console.WriteLine("======================================");
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}


/*jawaban =
 2. saya menggunakan algoritma = singly link list dan double link list
 3. stack = double link list dan circular link list
 4. ditambahkan diakhir = REAR
dihapus diakhir = FRONT
 5. a. kedalaman = 5 Level
 b. PREORDER Traversal = 25 20 10 5 1 8 15 12 22 36 30 28 40 38 48 45 50
 
 
 
 */
