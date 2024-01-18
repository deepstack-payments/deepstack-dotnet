using DeepStack.Extensions;

namespace DeepStack.Entities.Base
{
    /// <summary>
    /// Base class for all Globally Paid entities
    /// </summary>
    public abstract class Entity
    {
        public override string ToString()
        {
            return $"<{GetType().FullName}> JSON: {this.ToJson()}";
        }
    }
}
