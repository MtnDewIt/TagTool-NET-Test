using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags.Definitions.Gen2
{
    [TagStructure(Name = "item", Tag = "item", Size = 0x12C)]
    public class Item : GameObject
    {
        public ItemFlagsValue ItemFlags;
        public short OldMessageIndex;
        public short SortOrder;
        public float MultiplayerOnGroundScale;
        public float CampaignOnGroundScale;
        /// <summary>
        /// everything you need to display stuff
        /// </summary>
        public StringId PickupMessage;
        public StringId SwapMessage;
        public StringId PickupOrDualWieldMessage;
        public StringId SwapOrDualWieldMessage;
        public StringId DualOnlyMsg;
        public StringId PickedUpMessage;
        public StringId SingluarQuantityMsg;
        public StringId PluralQuantityMsg;
        public StringId SwitchToMessage;
        public StringId SwitchToFromAiMessage;
        [TagField(ValidTags = new[] { "foot" })]
        public CachedTag Unused;
        [TagField(ValidTags = new[] { "snd!" })]
        public CachedTag CollisionSound;
        public List<PredictedBitmapsBlock> PredictedBitmaps;
        [TagField(ValidTags = new[] { "jpt!" })]
        public CachedTag DetonationDamageEffect;
        public Bounds<float> DetonationDelay; // seconds
        [TagField(ValidTags = new[] { "effe" })]
        public CachedTag DetonatingEffect;
        [TagField(ValidTags = new[] { "effe" })]
        public CachedTag DetonationEffect;

        [Flags]
        public enum ItemFlagsValue : uint
        {
            AlwaysMaintainsZUp = 1 << 0,
            DestroyedByExplosions = 1 << 1,
            UnaffectedByGravity = 1 << 2
        }

        [TagStructure(Size = 0x8)]
        public class PredictedBitmapsBlock : TagStructure
        {
            [TagField(ValidTags = new[] { "bitm" })]
            public CachedTag Bitmap;
        }
    }
}
