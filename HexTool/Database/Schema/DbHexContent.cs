using HexTool.Model.HexMap;
using SqliteDatabaseLibrary;

namespace HexTool.Database.Schema
{
    public class DbHexContent : DbObjectModule<HexContent>
    {
        public override string TableName => "HexContentTable";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true, false, true),
            new DbColumn(X, DbColumn.Integer),
            new DbColumn(Y, DbColumn.Integer),
            new DbColumn(BackgroundImageId, DbColumn.Integer),
            new DbColumn(TerrainImageId, DbColumn.Integer),
            new DbColumn(VegetationImageId, DbColumn.Integer),
            new DbColumn(FeatureImageId, DbColumn.Integer),
        };

        public const string X = "X";
        public const string Y = "Y";
        public const string BackgroundImageId = "BackgroundImageId";
        public const string TerrainImageId = "TerrainImageId";
        public const string VegetationImageId = "VegetationImageId";
        public const string FeatureImageId = "FeatureImageId";

        public DbHexContent(SqliteDbInterface dbInterface, SqLiteDb db) : base(dbInterface, db)
        { }

        public long Create(HexContent item)
        {
            return Db.Insert(TableName,
                new[] { X, Y, BackgroundImageId, TerrainImageId, VegetationImageId, FeatureImageId }, 
                new[] { item.X.ToString(), item.Y.ToString(), item.BackgroundImageId.ToString(), item.TerrainImageId.ToString(), item.VegetationImageId.ToString(), item.FeatureImageId.ToString() });
        }
                
        protected override HexContent MakeObject(object[] dbObject)
        {
            DbResultReader reader = new DbResultReader(dbObject);
            var id = reader.ReadLong();
            var x = reader.ReadInt();
            var y = reader.ReadInt();
            var backgroundImageId = reader.ReadInt();
            var terrainImageId = reader.ReadInt();
            var vegetationImageId = reader.ReadInt();
            var featureImageId = reader.ReadInt();

            var item = new HexContent {
                Id = id,
                X = x,
                Y = y,
                BackgroundImageId = backgroundImageId,
                TerrainImageId = terrainImageId,
                VegetationImageId = vegetationImageId,
                FeatureImageId = featureImageId,
            };

            return item;
        }
    }
}
