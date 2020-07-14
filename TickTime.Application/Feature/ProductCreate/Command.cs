using MediatR;
using System;
using System.Runtime.Serialization;

namespace TickTime.Application.Feature.ProductCreate
{
    public partial class ProductCreate
    {
        [DataContract]
        public class Command : IRequest<Guid>
        {
            [DataMember]
            public string Name { get; set; }

            public Command(string name)
            {
                Name = name;
            }
        }
    }
}
