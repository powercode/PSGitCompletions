using System;

namespace PowerCode
{
    public struct GitRef
    {
        public enum ObjectType
        {
            Blob,
            Tree,
            Commit,
            Tag
        }

        public string Commit { get; }
        public ObjectType Type { get; }
        public string Name { get; }
        public string Subject { get; }

        public GitRef(string commit, ObjectType type, string name, string subject)
        {
            Commit = commit;
            Type = type;
            Name = name;
            Subject = subject;
        }
    }
}