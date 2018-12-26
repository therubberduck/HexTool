namespace HexTool.Model.HexMap
{
    public class MapBrush
    {
        public string Name { get; private set; }
        public int BackgroundId { get; private set; }
        public int TerrainId { get; private set; }
        public int VegetationId { get; private set; }
        public int FeatureId { get; private set; }

        public MapBrush(string name, 
            int backgroundId, int terrainId,
            int vegetationId, int featureId)
        {
            Name = name;
            BackgroundId = backgroundId;
            TerrainId = terrainId;
            VegetationId = vegetationId;
            FeatureId = featureId;
        }
    }
}
