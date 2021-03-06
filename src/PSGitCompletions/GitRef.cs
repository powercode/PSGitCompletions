using System;

namespace PowerCode
{
    public struct GitRef
    {

        public string Commit { get; }
        public GitObjectType ObjectType { get; }
        public string Name { get; }
        public string Subject { get; }

        public GitRef(string commit, GitObjectType objectType, string name, string subject)
        {
            Commit = commit;
            ObjectType = objectType;
            Name = name;
            Subject = subject;
        }
    }

    public enum GitObjectType
    {
        Blob,
        Tree,
        Commit,
        Tag
    }
}