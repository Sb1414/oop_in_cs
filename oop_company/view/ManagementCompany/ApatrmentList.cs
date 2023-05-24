using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementCompany
{
    internal class ApartmentsList
    {
        private class Node
        {
            public Apartment apartment;
            public Node next;
            public Node(Apartment apartment)
            {
                this.apartment = apartment;
                this.next = null;
            }
        }

        private Node head;
        private int count;

        public int GetCount()
        {
            return count;
        }

        public void AddApartment(Apartment apartment)
        {
            Node newNode = new Node(apartment);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
            count++;
        }

        public void RemoveApartmentByNumber(int apartmentNumber)
        {
            Node current = head;
            Node prev = null;
            while (current != null)
            {
                if (current.apartment.GetNumber() == apartmentNumber)
                {
                    if (prev == null)
                    {
                        head = current.next;
                    }
                    else
                    {
                        prev.next = current.next;
                    }
                    count--;
                    break;
                }
                prev = current;
                current = current.next;
            }
        }


        public void RemoveApartment(Apartment apartment)
        {
            Node current = head;
            Node prev = null;
            while (current != null)
            {
                if (current.apartment == apartment)
                {
                    if (prev == null)
                    {
                        head = current.next;
                    }
                    else
                    {
                        prev.next = current.next;
                    }
                    count--;
                    break;
                }
                prev = current;
                current = current.next;
            }
            
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public Apartment FindApartment(int numberApart)
        {
            if (numberApart < 0 || numberApart >= count)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = head;
            for (int i = 0; i < numberApart; i++)
            {
                current = current.next;
            }
            return current.apartment;
        }

        public decimal GetTotalPayments()
        {
            decimal total = 0;
            Node current = head;
            while (current != null)
            {
                total += current.apartment.GetPayment();
                current = current.next;
            }
            return total;
        }

        public Apartment this[int index]
        {
            get
            {
                return FindApartment(index);
            }
        }

        public List<Apartment> GetAllApartments()
        {
            List<Apartment> apartments = new List<Apartment>();

            Node current = head;
            while (current != null)
            {
                apartments.Add(current.apartment);
                current = current.next;
            }

            return apartments;
        }
    }
}
