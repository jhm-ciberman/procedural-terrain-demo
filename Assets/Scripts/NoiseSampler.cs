class NoiseSampler 
{
    public float persistence = 0.5f;
    public float lacunarity = 2f;
    public float scale = 20f;
    private SimplexNoise _noise; 

    public NoiseSampler(int seed)
    {
        this._noise = new SimplexNoise(seed);
    }

    public float Sample(int x, int y)
    {
        float amplitude = 1;
        float frecuency = 1;
        float noiseHeight = 0;

        for (int i = 0; i < 4; i++) 
        {
            float scale = frecuency / this.scale;

            float noiseValue = this._noise.Sample(scale * x, scale * y);
            noiseHeight += amplitude * noiseValue;

            amplitude *= this.persistence;
            frecuency *= this.lacunarity;
        }

        return noiseHeight / 3.75f;
    }
}
