using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App4.Models
{
    public class OrderInfoRepository
    {
        private ObservableCollection<OrderInfo> orderInfo;
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo(615081, "Li", "Lin", "Chinese", "02/06/1979", 1957, "Private", "Active", "English", "54 Islington Park St, London, N1 1PX", "Y", "EUR"));
            orderInfo.Add(new OrderInfo(411106, "Bai", "Hao", "Chinese", "16/01/1969", 1957, "Private", "Active", "English", "37 Grove Road London SW46 9AK", "Y", "CHF"));
            orderInfo.Add(new OrderInfo(659412, "Utemaro", "Watase", "Japanese", "13/03/1970", 1957, "Private", "Active", "English", "Grayrigg Cottage, Kents Bank Rd, Grange-Over-Sands, LA11 7HD", "Y", "CHF"));
            orderInfo.Add(new OrderInfo(119331, "Hernández", "Ximena", "Mexican", "11/07/1945", 1957, "Private", "Active", "English", "61 Richmond Avenue, London, N1 0LX", "Y", "CHF"));
            orderInfo.Add(new OrderInfo(729818, "Montandon", "Rachael", "Swiss", "07/11/1968", 2107, "Private", "Active", "English, French", "38 Chester Road London SE19 4SZ", "Y", "CHF"));
            orderInfo.Add(new OrderInfo(442232, "Stager", "Isabelle", "Swiss", "15/10/1959", 2107, "Private", "Active", "English, French", "25 Imperial Rd, Windsor, SL4 3RU", "Y", "CHF"));
            orderInfo.Add(new OrderInfo(168652, "Surbeck", "Peter", "Swiss", "05/07/1966", 2107, "Private", "Active", "English, French", "1 Islington Green, London, N1 2XH", "Y", "CHF"));
            orderInfo.Add(new OrderInfo(203871, "Juric", "Jan", "Croatian", "05/03/1943", 2781, "Private", "Active", "English", "St. Marys Church, Upper St, London, N1 2TX", "Y", "EUR"));
            orderInfo.Add(new OrderInfo(479324, "Travers", "Millard", "French", "26/06/1941", 2781, "Private", "Active", "English, French", "9 Rectory Terrace, High St, Cambridge, CB1 9HU", "Y", "EUR"));
            orderInfo.Add(new OrderInfo(690762, "Charpentier", "Leon", "French", "29/07/1958", 2781, "Private", "Active", "English, French", "52 West Street London NW78 6ZV", "Y", "EUR"));
            orderInfo.Add(new OrderInfo(604082, "Dupuis", "Louis", "French", "10/11/1966", 2781, "Private", "Active", "English, French", "10 Gardiner Rd, Edinburgh, EH4 3RR", "Y", "EUR"));
            orderInfo.Add(new OrderInfo(754641, "Sergeyevna", "Selidova", "Russian", "12/02/1945", 2781, "Private", "Active", "English", "Manchester House, 50, High St, Builth Wells, LD2 3AD", "Y", "USD"));
            orderInfo.Add(new OrderInfo(102966, "Aleskeevich", "Yagovkin", "Russian", "29/12/1959", 2781, "Private", "Active", "English", "5 Richmond Road London W49 6CF", "Y", "USD"));

        }
    }
}
