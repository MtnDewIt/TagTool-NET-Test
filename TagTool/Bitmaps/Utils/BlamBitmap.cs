using TagTool.Bitmaps;
using TagTool.Tags.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Tags.Resources;
using TagTool.Bitmaps.DDS;

public class BaseBitmap
{
    public int Height;
    public int Width;
    public int Depth;
    public int MipMapCount;
    public BitmapFormat Format;
    public int BlockSize;
    public BitmapType Type;
    public BitmapImageCurve Curve;
    public BitmapFlags Flags;
    public int MipMapOffset;
    public byte[] Data;

    public BaseBitmap() { }

    public BaseBitmap(Bitmap.Image image, byte[] data) : this(image)
    {
        Data = data;
    }

    public BaseBitmap(Bitmap.Image image)
    {
        Height = image.Height;
        Width = image.Width;
        Depth = image.Depth;
        MipMapCount = image.MipmapCount + 1;
        Type = image.Type;
        Flags = image.Flags;
        Curve = image.Curve;
        MipMapOffset = image.HighResPixelsSize;
        UpdateFormat(image.Format);
    }

    public BaseBitmap(BitmapTextureInteropResource definition, Bitmap.Image image) : this(definition.Texture.Definition.Bitmap, image)
    {
    }

    public BaseBitmap(BitmapTextureInteropDefinition definition, Bitmap.Image image)
    {
        Height = definition.Height;
        Width = definition.Width;
        Depth = definition.Depth;
        MipMapCount = Math.Max(1, (int)definition.MipmapCount);
        Type = definition.BitmapType;
        Flags = image.Flags;
        Curve = image.Curve;
        MipMapOffset = image.HighResPixelsSize;
        UpdateFormat(image.Format);
    }

    public BaseBitmap(BitmapTextureInterleavedInteropResource definition, int index, Bitmap.Image image)
    {
        
        if(index == 0)
        {
            var def = definition.Texture.Definition.Bitmap1;
            Height = def.Height;
            Width = def.Width;
            Depth = def.Depth;
            MipMapCount = Math.Max(1, (int)def.MipmapCount);
            Type = def.BitmapType;
            Flags = image.Flags;
            UpdateFormat(image.Format);
        }
        else
        {
            var def = definition.Texture.Definition.Bitmap2;
            Height = def.Height;
            Width = def.Width;
            Depth = def.Depth;
            MipMapCount = Math.Max(1, (int)def.MipmapCount);
            Type = def.BitmapType;
            Flags = image.Flags;
            UpdateFormat(image.Format);
        }
        MipMapOffset = image.HighResPixelsSize;
        Curve = image.Curve;
    }

    public BaseBitmap(BaseBitmap bitmap)
    {
        Height = bitmap.Height;
        Width = bitmap.Width;
        Depth = bitmap.Depth;
        MipMapCount = bitmap.MipMapCount;
        Type = bitmap.Type;
        Flags = bitmap.Flags;
        Curve = bitmap.Curve;
        UpdateFormat(bitmap.Format);
    }

    public void UpdateFormat(BitmapFormat format)
    {
        Format = format;
        BlockSize = BitmapFormatUtils.GetBlockSize(Format);
        if (BitmapUtils.IsCompressedFormat(format))
            Flags |= BitmapFlags.Compressed;
        else
            Flags &= ~BitmapFlags.Compressed;
    }
}
