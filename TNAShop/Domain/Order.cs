using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class Order {
        public int Id { set; get; }
        [Display(Name ="Ngày hóa đơn")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime OrderDate { set; get; }
        [Display(Name ="Trạng thái đơn hàng")]
        public bool Status { set; get; }
        [Display(Name ="Email người nhận")]
        public string Email { set; get; }
        [Display(Name ="Giá đơn hàng")]
        public double TotalCost { set; get; }
        [Display(Name ="Tên khách hàng")]
        public string CustomerName { set; get; }
        [Display(Name ="Số điện thoại")]
        public string PhoneNumber { set; get; }
        [Display(Name ="Địa chỉ nhận hàng")]
        public string Address { set; get; }
        [Display(Name ="Cách giao hàng")]
        public string TransportionType { set; get; }
        [Display(Name = "Khách hàng ghi chú")]
        public string Note { set; get; }
        [Display(Name = "Cách thức thanh toán")]
        public string PaymentType { set; get; }

        public virtual ICollection<OrderDet> OrderDets { set; get; }
        IOrderRepository repos;
        public Order() {
            OrderDate = DateTime.Now;
        }
        public Order(IOrderRepository repos) {
            OrderDate = DateTime.Now;
            this.repos = repos;
        }
        public void AddOrder(Order order) {
            repos.AddOrder(order);
        }
    }
    public interface IOrderRepository {
        void AddOrder(Order order);
    }
}