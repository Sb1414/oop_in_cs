using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Shop
    {
        private OrderNode Head;
        private OrderNode Tail;
        private int OrdersCount;
        private Dictionary<string, OrderNode> OrderNodes = new Dictionary<string, OrderNode>();

        public Shop()
        {
            Head = null;
            Tail = null;
            OrdersCount = 0;
        }

        public int GetSumOfAllOrders()
        {
            int sum = 0;
            OrderNode current = Head;
            while (current != null)
            {
                sum += current.Order.GetSumOfOrder();
                current = current.Next;
            }
            return sum;
        }

        public string GetData()
        {
            string data = "";
            OrderNode current = Head;
            int number = 1;
            while (current != null)
            {
                data += $"\n[{number}]\n{current.Order.GetData()}";
                current = current.Next;
                number++;
            }
            return data;
        }

        public bool AddOrder(string name, string date)
        {
            Order newOrder = new Order(name, date);
            OrderNode newNode = new OrderNode(newOrder);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                OrderNodes[name] = newNode;
            }
            else
            {
                OrderNode current = Head;
                while (current != null && string.Compare(name, current.Order.GetName()) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    // Insert at the end
                    Tail.Next = newNode;
                    newNode.Previous = Tail;
                    Tail = newNode;
                }
                else
                {
                    // Insert before current
                    if (current.Previous == null)
                    {
                        // Insert at the beginning
                        newNode.Next = current;
                        current.Previous = newNode;
                        Head = newNode;
                    }
                    else
                    {
                        newNode.Next = current;
                        newNode.Previous = current.Previous;
                        current.Previous.Next = newNode;
                        current.Previous = newNode;
                    }
                }

                OrderNodes[name] = newNode;
            }

            OrdersCount++;
            return true;
        }

        public bool AddProductToOrder(string customerName, string productName, int price)
        {
            OrderNode node = FindOrderNode(customerName);
            if (node != null)
            {
                node.Order.AddInOrder(productName, price);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteOrder(string customerName)
        {
            OrderNode node = FindOrderNode(customerName);
            if (node != null)
            {
                node.Order.RemoveAllProducts();

                if (node.Previous == null)
                {
                    // Deleting the head node
                    Head = node.Next;
                    if (Head != null)
                    {
                        Head.Previous = null;
                    }
                }
                else
                {
                    node.Previous.Next = node.Next;
                    if (node.Next != null)
                    {
                        node.Next.Previous = node.Previous;
                    }
                }

                if (node == Tail)
                {
                    // Deleting the tail node
                    Tail = node.Previous;
                }

                OrderNodes.Remove(customerName);

                OrdersCount--;
            }
        }

        public Order FindOrderByNumber(int orderNumber)
        {
            OrderNode current = Head;
            while (current != null)
            {
                if (GetOrderNumber(current) == orderNumber)
                {
                    return current.Order;
                }
                current = current.Next;
            }
            return null;
        }

        public int CalculateTotalOrderCost()
        {
            int totalCost = 0;
            OrderNode current = Head;
            while (current != null)
            {
                totalCost += current.Order.GetSumOfOrder();
                current = current.Next;
            }
            return totalCost;
        }


        public Order FindOrder(string name)
        {
            OrderNode node = FindOrderNode(name);
            if (node != null)
            {
                return node.Order;
            }
            else
            {
                return null;
            }
        }

        public bool AddProductToOrder(int orderNumber, string productName, int price)
        {
            OrderNode node = FindOrderNode(orderNumber);
            if (node != null)
            {
                node.Order.AddInOrder(productName, price);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetOrderNumberByName(string name)
        {
            if (OrderNodes.ContainsKey(name))
            {
                OrderNode node = OrderNodes[name];
                int orderNumber = GetOrderNumber(node);
                return orderNumber;
            }
            else
            {
                return -1;
            }
        }

        public int GetTotalOrderAmount(string name)
        {
            OrderNode node = FindOrderNode(name);
            if (node != null)
            {
                return node.Order.GetSumOfOrder();
            }
            else
            {
                return 0;
            }
        }

        public bool IsPersonExists(string name)
        {
            return OrderNodes.ContainsKey(name);
        }

        public void RemoveAllProducts()
        {
            OrderNode current = Head;
            while (current != null)
            {
                current.Order.RemoveAllProducts();
                current = current.Next;
            }
        }

        public void RemoveAllOrders()
        {
            Head = null;
            Tail = null;
            OrdersCount = 0;
            OrderNodes.Clear();
        }

        public bool RemoveProductFromOrder(string customerName, string productName)
        {
            OrderNode node = FindOrderNode(customerName);
            if (node != null)
            {
                node.Order.RemoveProductByName(productName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveProduct(string productName, int price)
        {
            OrderNode current = Head;
            while (current != null)
            {
                current.Order.RemoveProduct(new Product(productName, price));
                current = current.Next;
            }
        }

        public void RemoveOrderAndProductsByCustomerName(string customerName)
        {
            OrderNode node = FindOrderNode(customerName);
            if (node != null)
            {
                node.Order.RemoveAllProducts();
                DeleteOrder(customerName);
            }
        }

        public Product[] GetProductsByCustomerName(string customerName)
        {
            OrderNode node = FindOrderNode(customerName);
            if (node != null)
            {
                return node.Order.GetAllProducts();
            }
            else
            {
                return new Product[0];
            }
        }

        public Product[] GetAllProductsByName(string productName)
        {
            List<Product> productsList = new List<Product>();
            OrderNode current = Head;
            while (current != null)
            {
                Product[] orderProducts = current.Order.GetProductsByName(productName);
                productsList.AddRange(orderProducts);
                current = current.Next;
            }
            return productsList.ToArray();
        }

        public Order[] GetAllOrders()
        {
            Order[] allOrders = new Order[OrdersCount];
            OrderNode current = Head;
            int index = 0;
            while (current != null)
            {
                allOrders[index] = current.Order;
                current = current.Next;
                index++;
            }
            return allOrders;
        }

        private OrderNode FindOrderNode(string name)
        {
            if (OrderNodes.ContainsKey(name))
            {
                return OrderNodes[name];
            }
            else
            {
                return null;
            }
        }

        private OrderNode FindOrderNode(int orderNumber)
        {
            OrderNode current = Head;
            while (current != null)
            {
                if (GetOrderNumber(current) == orderNumber)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        private int GetOrderNumber(OrderNode node)
        {
            int orderNumber = 1;
            OrderNode current = Head;
            while (current != null)
            {
                if (current == node)
                {
                    return orderNumber;
                }
                current = current.Next;
                orderNumber++;
            }
            return -1;
        }

        private class OrderNode
        {
            public Order Order { get; }
            public OrderNode Previous { get; set; }
            public OrderNode Next { get; set; }

            public OrderNode(Order order)
            {
                Order = order;
                Previous = null;
                Next = null;
            }
        }
    }

}
