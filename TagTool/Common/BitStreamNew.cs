namespace TagTool.Common
{
    public class BitStreamNew
    {
        public enum BitStreamState : int
        {
            None = 0,

            Write,
            WriteFinished,

            Read,
            ReadConsistencyCheck,
            ReadFinished,

            StateCount,
        }

        private static readonly int BITSTREAM_MAXIMUM_POSITION_STACK_SIZE = 0x4;

        public class BitStreamStackEntry
        {
            public int CurrentMemoryBitPosition;
            public int CurrentStreamBitPosition;
            public ulong Accumulator;
            public int AccumulatorBitCount;
            public byte[] NextData;
        }

        public byte[] Data;
        public byte[] DataMax;
        public int DataSizeBytes;
        public int DataSizeAlignment;
        public int State;
        public bool DataErrorDetected;
        public BitStreamStackEntry BitStreamData;
        public int PositionStackDepth;
        public BitStreamStackEntry[] PositionStack = new BitStreamStackEntry[BITSTREAM_MAXIMUM_POSITION_STACK_SIZE];
        public int NumberOfBitsRewound;
        public int NumberOfPositionResets;

        /*
        public BitStreamNew()
        {
            Data = null;
            DataMax = null;
            DataSizeBytes = 0;

            Reset((int)BitStreamState.None);
        }

        public BitStreamNew(byte[] data, int dataSizeBytes) 
        {
            DataSizeAlignment = 0x1;

            SetData(data, dataSizeBytes);
        }

        public bool ReadBool() 
        {
            
        }

        public uint ReadInteger(int sizeInBits) 
        {
            
        }

        public void ReadRawData(byte[] RawData, int sizeInBits) 
        {
            
        }

        public int ReadSignedInteger(int sizeInBits) 
        {
            
        }

        public void WriteBitInternal(bool value) 
        {
            
        }

        public bool WriteBool(bool value) 
        {

        }

        public void WriteUInt32Internal(uint value, int sizeInBits) 
        {
            
        }

        public void WriteInteger(uint value, int sizeInBits) 
        {
            
        }

        public void WriteRawData(byte[] rawData, int sizeInBits) 
        {

        }

        public void WriteSignedInteger(int value, int sizeInBits) 
        {

        }

        public ulong ReadUInt64(int sizeInBits) 
        {

        }

        public void WriteUInt64(ulong value, int sizeInBits) 
        {

        }

        public static void AngleToAxesInternal(RealVector3d up, float angle, RealVector3d forward) 
        {
            
        }

        public void Append(BitStreamNew stream) 
        {
            
        }

        public static void AxesComputeReferenceInternal(RealVector3d up, RealVector3d forwardReference, RealVector3d leftReference) 
        {
            
        }

        public static float AxesToAngleInternal(RealVector3d forward, RealVector3d up) 
        {
            
        }

        public void BeginConsistencyCheck() 
        {
            
        }

        public void BeginReading() 
        {
            
        }

        public void BeginWriting(int dataSizeAlignment) 
        {

        }

        public void DataIsUntrusted(bool isUntrusted) 
        {
            
        }

        private ulong DecodeUInt64FromMemory() 
        {
            
        }

        public void DiscardRemainingData() 
        {
            
        }

        private void EncodeUInt64ToMemory(ulong value, int bitCount) 
        {

        }

        public bool Overflowed() 
        {
            
        }

        public bool ErrorOccured() 
        {
            
        }

        public bool WasReading() 
        {
            
        }

        public bool WasWriting() 
        {
            
        }

        public void FinishConsistencyCheck() 
        {

        }

        public void FinishReading() 
        {

        }

        public void FinishWriting(int bitsWasted) 
        {

        }

        public int GetCurrentStreamBitPosition() 
        {

        }

        public int GetSpaceUsedInBits() 
        {
            
        }

        public byte[] GetData(int dataLength) 
        {

        }

        public void PushPosition() 
        {

        }

        public void PopPosition(bool resetToPushedState) 
        {
            
        }

        private ulong ReadAccumulatorFromMemory(int sizeInBits) 
        {
            
        }

        public bool ReadBitInternal() 
        {
            
        }

        public void ReadBitsInternal(byte[] data, int sizeInBits) 
        {

        }

        public uint ReadUInt32Internal(int sizeInBits) 
        {
            
        }

        public void ReadIdentifier() 
        {

        }

        public float ReadLogarithmicQuantizedReal(float minValue, float maxValue, int sizeInBits) 
        {
            
        }

        public void ReadPoint3d(Point3d point, int axisEncodingSizeInBits) 
        {
            
        }

        public float ReadQuantizedReal(float minValue, float maxValue, int sizeInBits, bool exactMidPoint, bool exactEndPoints) 
        {
            
        }

        public ulong ReadUInt64Internal(int sizeInBits) 
        {

        }

        public void ReadSecureAddress(TransportSecureAddress address) 
        {
            
        }

        public void ReadString(string inputString, int maxStringSize) 
        {
            
        }

        public void ReadStringUTF8(string charString, int maxStringSize) 
        {
            
        }

        public void ReadStringWChar(string inputString, int maxStringSize) 
        {
            
        }

        public void ReadUnitVector(RealVector3d value, float minMagnitude, float maxMagnitude, int magnitudeSizeInBits, int sizeInBits) 
        {
            
        }

        public bool Reading() 
        {
            
        }

        private void Reset(int state) 
        {
            
        }

        public void SetData(byte[] data, int dataLength) 
        {
            
        }

        public void Skip(int bitsToSkip) 
        {
            
        }

        public bool WouldOverflow(int sizeInBits) 
        {

        }

        public void WriteAccumulatorToMemory(ulong value, int sizeInBits) 
        {

        }

        public void WriteBitsInternal(byte[] data, int sizeInBits) 
        {
            
        }

        public void WriteIdentifier() 
        {

        }

        public void WritePoint3d(Point3d point, int axisEncodingSizeInBits) 
        {
            
        }

        public void WritePoint3dEfficient(Point3d point1, Point3d point2) 
        {
            
        }

        public void WriteQuantizedReal(float value, float minValue, float maxValue, int sizeInBits, bool exactMidPoint, bool exactEndPoints) 
        {
            
        }

        public void WriteUInt64Internal(ulong value, int sizeInBits) 
        {
            
        }

        public void WriteSecureAddress(TransportSecureAddress address) 
        {

        }

        public void WriteString(string inputString, int maxStringSize) 
        {

        }

        public void WriteStringUTF8(string charString, int maxStringSize) 
        {

        }

        public void WriteStringWChar(string inputString, int maxStringSize) 
        {

        }

        public void WriteUnitVector(RealVector3d value, int sizeInBits) 
        {
            
        }

        public void WriteVector(RealVector3d value, float minValue, float maxValue, int stepCountSizeInBits, int sizeInBits) 
        {
            
        }
        */
    }
}
