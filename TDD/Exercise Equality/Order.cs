using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Equality
{

    public class Order : IComparable<Order>, IEquatable<Order> 
    {
        public int OrderId;
        public List<OrderLine> orderLines { get; private set; }

        public Order()
        {
            orderLines = new List<OrderLine>();
        }

        public void AddOrderLine(OrderLine orderline)
        {
            if (!orderLines.Contains(orderline))
                orderLines.Add(orderline);
        }
        //public int CompareTo(Order other)
        //{
        //    
            
            
        //}
        public override bool Equals(object obj)
        {
            return base.Equals(obj as Order);
        }
        public bool Equals(Order other)
        {
            int response = 0;
            bool answer = false;
            if (other == null)
                return false;
            else if (this.OrderId != other.OrderId)
                return false;
            else if (this.OrderId == other.OrderId)
            {
                foreach (var order2 in other.orderLines)
                {
                    foreach (var order1 in orderLines)
                    {
                        response = order1.Name.CompareTo(order2.Name);
                        if (response == 0)
                        {
                            response = order1.Price.CompareTo(order2.Price);
                            if (response == 0)
                            {
                                answer = true;
                            }
                            else
                                answer = false;

                        }
                        else
                            answer = false;
                    }

                }
                return answer;
            }
            //return response;
            //&&
            //    this.orderLines.Select(x => x.Name) == 
            //    other.orderLines.Select(x => x.Name))                

            else
                return false;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((OrderId != 0 ? OrderId.GetHashCode() : 0) * 397); //^
                //(orderLines != null ? orderLines.GetHashCode() : 0);
            }
        }

        public int CompareTo(Order other)
        {
            
            int response = 0;
            if (OrderId != other.OrderId)
            {
                response = OrderId.CompareTo(other.OrderId);
            }
            if (OrderId == other.OrderId)
            {
                foreach (var order2 in other.orderLines)
                {
                    foreach (var order1 in orderLines)
                    {
                        response = order1.Name.CompareTo(order2.Name);
                        if (response == 0)
                        {
                            response = order1.Price.CompareTo(order2.Price);
                            
                        }
                        //return response;
                    }
                    
                }
            }
            return response;


        }
    }

    public class OrderLine : IComparable<OrderLine> , IEquatable<OrderLine>
    {

        public string Name;
        public decimal Price;
        public int Quantity;


        public int CompareTo(OrderLine other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Price.CompareTo(other.Price);
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj as OrderLine);
        }
        public bool Equals(OrderLine other)
        {
            if (other == null)
                return false;
            if (this.Name == other.Name && 
                this.Price == other.Price && 
                this.Quantity == other.Quantity)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^
                (Price != 0 ? Price.GetHashCode() : 0);
            }
        }
    }
}
