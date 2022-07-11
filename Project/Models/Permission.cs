using Project.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

#nullable disable

namespace Project.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }

        public Permission(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Status = bool.Parse(row["status"].ToString());
        }

        public virtual ICollection<Action> Actions
        {
            get
            {
                return ADO.ActionADO.GetList(Id, true);
            }
        }
        public virtual ICollection<Feature> Features
        {
            get
            {
                ICollection<Feature> features = new List<Feature>();
                foreach(Action action in Actions)
                {
                    Feature feature = ADO.FeatureADO.GetFeature(action);
                    try
                    {
                        feature = features.First(x => x.Id == feature.Id);
                    }
                    catch (Exception)
                    {
                        features.Add(feature);
                    }

                }
                return features.Distinct().ToList() ;
            }
        }
    }
}
