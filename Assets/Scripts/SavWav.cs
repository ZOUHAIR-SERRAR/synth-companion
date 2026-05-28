using System;
using System.IO;
using UnityEngine;

public static class SavWav
{
    private const int HEADER_SIZE = 44;

    public static bool Save(string filename, AudioClip clip)
    {
        if (!filename.ToLower().EndsWith(".wav"))
        {
            filename += ".wav";
        }

        string filepath = filename;
        Directory.CreateDirectory(Path.GetDirectoryName(filepath));

        using (var fileStream = new FileStream(filepath, FileMode.Create))
        {
            byte emptyByte = new byte();
            for (int i = 0; i < HEADER_SIZE; i++) // Préparation de l'en-tête du fichier
            {
                fileStream.WriteByte(emptyByte);
            }

            ConvertAndWrite(fileStream, clip);
            WriteHeader(fileStream, clip);
        }

        return true;
    }

    private static void ConvertAndWrite(FileStream fileStream, AudioClip clip)
    {
        var samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);

        Int16[] intData = new Int16[samples.Length];
        Byte[] bytesData = new Byte[samples.Length * 2];

        int rescaleFactor = 32767; // Conversion du format float de Unity en Int16 pour le WAV

        for (int i = 0; i < samples.Length; i++)
        {
            intData[i] = (Int16)(samples[i] * rescaleFactor);
            Byte[] byteArr = BitConverter.GetBytes(intData[i]);
            byteArr.CopyTo(bytesData, i * 2);
        }

        fileStream.Write(bytesData, 0, bytesData.Length);
    }

    private static void WriteHeader(FileStream fileStream, AudioClip clip)
    {
        var hz = clip.frequency;
        var channels = clip.channels;
        var samples = clip.samples;

        fileStream.Seek(0, SeekOrigin.Begin);

        Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
        fileStream.Write(riff, 0, 4);

        Byte[] chunkSize = BitConverter.GetBytes(fileStream.Length - 8);
        fileStream.Write(chunkSize, 0, 4);

        Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
        fileStream.Write(wave, 0, 4);

        Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
        fileStream.Write(fmt, 0, 4);

        Byte[] subChunk1 = BitConverter.GetBytes(16);
        fileStream.Write(subChunk1, 0, 4);

        UInt16 audioFormat = 1; // Format PCM non compressé
        fileStream.Write(BitConverter.GetBytes(audioFormat), 0, 2);

        UInt16 numChannels = (UInt16)channels;
        fileStream.Write(BitConverter.GetBytes(numChannels), 0, 2);

        UInt32 sampleRate = (UInt32)hz;
        fileStream.Write(BitConverter.GetBytes(sampleRate), 0, 4);

        UInt32 byteRate = (UInt32)(hz * channels * 2);
        fileStream.Write(BitConverter.GetBytes(byteRate), 0, 4);

        UInt16 blockAlign = (UInt16)(channels * 2);
        fileStream.Write(BitConverter.GetBytes(blockAlign), 0, 2);

        UInt16 bps = 16;
        fileStream.Write(BitConverter.GetBytes(bps), 0, 2);

        Byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
        fileStream.Write(datastring, 0, 4);

        Byte[] subChunk2 = BitConverter.GetBytes(fileStream.Length - HEADER_SIZE);
        fileStream.Write(subChunk2, 0, 4);
    }
}