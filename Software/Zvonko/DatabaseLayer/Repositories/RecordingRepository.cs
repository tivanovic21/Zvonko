using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories {
    public class RecordingRepository : Repository<Recording> {
        public RecordingRepository() : base(new ZvonkoModel()) {

        }
        public List<Recording> Get() {
            var query = from e in Entities
                        select e;
            return query.ToList();
        }
    }
}
