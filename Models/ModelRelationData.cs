using AuroraCore.Storage;
using System.Threading.Tasks;

namespace Parallax.Models {
    public class ModelRelationData {
        public int ID { get; private set; }
        public IRelation Relation { get; private set; }
        public bool Required { get; private set; }
        public int Cardinality { get; private set; }

        private ModelRelationData() {

        }

        public static async Task<ModelRelationData> Instantiate(IModelProperty<IRelation> relation) {
            var relationIndividual = await relation.GetProperty();
            var required = await relation.IsRequired();
            var cardinality = await relation.GetCardinality();

            return new ModelRelationData {
                ID = relation.ID,
                Required = required,
                Cardinality = cardinality,
                Relation = relationIndividual
            };
        }
    }
}