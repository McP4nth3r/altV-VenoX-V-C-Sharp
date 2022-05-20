using System;

namespace VenoX.Core._Language_.GoogleTranslateFreeApi
{
  public class GoogleTranslateIpBannedException: Exception
  {
    public enum Operation { TokenGeneration, Translation }

    public Operation OperationBanned { get; }
    
    public GoogleTranslateIpBannedException(string message, Operation operation)
      :base("Google translate banned this IP for some time (about a few hours). " + message)
    {
      OperationBanned = operation;
    }

    public GoogleTranslateIpBannedException(Operation operation)
      :this(String.Empty, operation) { }
  }
}