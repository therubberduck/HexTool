namespace HexTool.Model.HexMap
{
    public class MapBrush
    {
        public string Name { get; }
        public int BackgroundId { get; }
        public int TerrainId { get; }
        public int VegetationId { get; }
        public int FeatureId { get; }

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
