using System;
using System.Linq;

namespace PowerCode
{
    public class GitCommand
    {
        public static GitCommand[] Commands =
        {
            #region Commands

            new GitCommand("add",
                "Add file contents to the index",
                @"git add [--verbose | -v] [--dry-run | -n] [--force | -f] [--interactive | -i] [--patch | -p]
	  [--edit | -e] [--[no-]all | --[no-]ignore-removal | [--update | -u]]
	  [--intent-to-add | -N] [--refresh] [--ignore-errors] [--ignore-missing]
	  [--chmod=(+|-)x] [--] [<pathspec>...]",
                @"This command updates the index using the current content found in the working tree, to prepare the content staged for the next commit. It typically adds the current content of existing paths as a whole, but with some options it can also be used to add content with only part of the changes made to the working tree files applied, or remove paths that do not exist in the working tree anymor"),
            new GitCommand("am",
                "Apply a series of patches from a mailbox",
                @"git am [--signoff] [--keep] [--[no-]keep-cr] [--[no-]utf8]
	 [--[no-]3way] [--interactive] [--committer-date-is-author-date]
	 [--ignore-date] [--ignore-space-change | --ignore-whitespace]
	 [--whitespace=<option>] [-C<n>] [-p<n>] [--directory=<dir>]
	 [--exclude=<path>] [--include=<path>] [--reject] [-q | --quiet]
	 [--[no-]scissors] [-S[<keyid>]] [--patch-format=<format>]
	 [(<mbox> | <Maildir>)...]
git am (--continue | --skip | --abort)",
                @"Splits mail messages in a mailbox into commit log message, authorship information and patches, and applies them to the current branch."),
            new GitCommand("annotate",
                "Annotate file lines with commit information",
                @"git annotate [options] file [revision]",
                @"Annotates each line in the given file with information from the commit which introduced the line. Optionally annotates from a given revision.


The only difference between this command and git-blame[1] is that they use slightly different output formats, and this command exists only for backward compatibility to support existing scripts, and provide a more familiar command name for people coming from other SCM systems."),
            new GitCommand("archive",
                "Create an archive of files from a named tree",
                @"git archive [--format=<fmt>] [--list] [--prefix=<prefix>/] [<extra>]
	      [-o <file> | --output=<file>] [--worktree-attributes]
	      [--remote=<repo> [--exec=<git-upload-archive>]] <tree-ish>
	      [<path>...]",
                @"Creates an archive of the specified format containing the tree structure for the named tree, and writes it out to the standard output. If <prefix> is specified it is prepended to the filenames in the archiv"),
            new GitCommand("bisect",
                "Use binary search to find the commit that introduced a bug",
                @"git bisect <subcommand> <options>",
                @"The command takes various subcommands, and different options depending on the subcommand:


git bisect start [--term-{old,good}=<term> --term-{new,bad}=<term>]
	  [--no-checkout] [<bad> [<good>...]] [--] [<paths>.."),
            new GitCommand("blame",
                "Show what revision and author last modified each line of a file",
                @"git blame [-c] [-b] [-l] [--root] [-t] [-f] [-n] [-s] [-e] [-p] [-w] [--incremental]
	    [-L <range>] [-S <revs-file>] [-M] [-C] [-C] [-C] [--since=<date>]
	    [--progress] [--abbrev=<n>] [<rev> | --contents <file> | --reverse <rev>..<rev>]
	    [--] <file>",
                @"Annotates each line in the given file with information from the revision which last modified the line. Optionally, start annotating from the given revision.


When specified one or more times, -L restricts annotation to the requested line"),
            new GitCommand("branch",
                "List, create, or delete branches",
                @"git branch [--color[=<when>] | --no-color] [-r | -a]
	[--list] [-v [--abbrev=<length> | --no-abbrev]]
	[--column[=<options>] | --no-column]
	[(--merged | --no-merged | --contains) [<commit>]] [--sort=<key>]
	[--points-at <object>] [<pattern>...]
git branch [--set-upstream | --track | --no-track] [-l] [-f] <branchname> [<start-point>]
git branch (--set-upstream-to=<upstream> | -u <upstream>) [<branchname>]
git branch --unset-upstream [<branchname>]
git branch (-m | -M) [<oldbranch>] <newbranch>
git branch (-d | -D) [-r] <branchname>...
git branch --edit-description [<branchname>]",
                @"If --list is given, or if there are no non-option arguments, existing branches are listed; the current branch will be highlighted with an asterisk. Option -r causes the remote-tracking branches to be listed, and option -a shows both local and remote branches. If a <pattern> is given, it is used as a shell wildcard to restrict the output to matching branches. If multiple patterns are given, a branch is shown if it matches any of the patterns. Note that when providing a <pattern>, you must use --list; otherwise the command is interpreted as branch creatio"),
            new GitCommand("bundle",
                "Move objects and refs by archive",
                @"git bundle create <file> <git-rev-list-args>
git bundle verify <file>
git bundle list-heads <file> [<refname>...]
git bundle unbundle <file> [<refname>...]",
                @"Some workflows require that one or more branches of development on one machine be replicated on another machine, but the two machines cannot be directly connected, and therefore the interactive Git protocols (git, ssh, http) cannot be used. This command provides support for git fetch and git pull to operate by packaging objects and references in an archive at the originating machine, then importing those into another repository using git fetch and git pull after moving the archive by some means (e.g., by sneakernet). As no direct connection between the repositories exists, the user must specify a basis for the bundle that is held by the destination repository: the bundle assumes that all objects in the basis are already in the destination repository."),
            new GitCommand("checkout",
                "Switch branches or restore working tree files",
                @"git checkout [-q] [-f] [-m] [<branch>]
git checkout [-q] [-f] [-m] --detach [<branch>]
git checkout [-q] [-f] [-m] [--detach] <commit>
git checkout [-q] [-f] [-m] [[-b|-B|--orphan] <new_branch>] [<start_point>]
git checkout [-f|--ours|--theirs|-m|--conflict=<style>] [<tree-ish>] [--] <paths>...
git checkout [-p|--patch] [<tree-ish>] [--] [<paths>...]",
                @"Updates files in the working tree to match the version in the index or the specified tree. If no paths are given, git checkout will also update HEAD to set the specified branch as the current branch."),
            new GitCommand("cherry",
                "Find commits yet to be applied to upstream",
                @"git cherry [-v] [<upstream> [<head> [<limit>]]]",
                @"Determine whether there are commits in <head>..<upstream> that are equivalent to those in the range <limit>..<head>.


The equivalence test is based on the diff, after removing whitespace and line numbers. git-cherry therefore detects when commits have been ""copied"" by means of git-cherry-pick[1], git-am[1] or git-rebase[1"),
            new GitCommand("cherry-pick",
                "Apply the changes introduced by some existing commits",
                @"git cherry-pick [--edit] [-n] [-m parent-number] [-s] [-x] [--ff]
		  [-S[<keyid>]] <commit>...
git cherry-pick --continue
git cherry-pick --quit
git cherry-pick --abort",
                @"Given one or more existing commits, apply the change each one introduces, recording a new commit for each. This requires your working tree to be clean (no modifications from the HEAD commit).


When it is not obvious how to apply a change, the following happen"),
            new GitCommand("citool",
                "Graphical alternative to git-commit",
                @"git citool",
                @"A Tcl/Tk based graphical interface to review modified files, stage them into the index, enter a commit message and record the new commit onto the current branch. This interface is an alternative to the less interactive git commit progra"),
            new GitCommand("clean",
                "Remove untracked files from the working tree",
                @"git clean [-d] [-f] [-i] [-n] [-q] [-e <pattern>] [-x | -X] [--] <path>...",
                @"Cleans the working tree by recursively removing files that are not under version control, starting from the current directory.


Normally, only files unknown to Git are removed, but if the -x option is specified, ignored files are also removed. This can, for example, be useful to remove all build product"),
            new GitCommand("clone",
                "Clone a repository into a new directory",
                @"git clone [--template=<template_directory>]
	  [-l] [-s] [--no-hardlinks] [-q] [-n] [--bare] [--mirror]
	  [-o <name>] [-b <name>] [-u <upload-pack>] [--reference <repository>]
	  [--dissociate] [--separate-git-dir <git dir>]
	  [--depth <depth>] [--[no-]single-branch]
	  [--recursive | --recurse-submodules] [--[no-]shallow-submodules]
	  [--jobs <n>] [--] <repository> [<directory>]",
                @"Clones a repository into a newly created directory, creates remote-tracking branches for each branch in the cloned repository (visible using git branch -r), and creates and checks out an initial branch that is forked from the cloned repository''s currently active branc"),
            new GitCommand("commit",
                "Record changes to the repository",
                @"git commit [-a | --interactive | --patch] [-s] [-v] [-u<mode>] [--amend]
	   [--dry-run] [(-c | -C | --fixup | --squash) <commit>]
	   [-F <file> | -m <msg>] [--reset-author] [--allow-empty]
	   [--allow-empty-message] [--no-verify] [-e] [--author=<author>]
	   [--date=<date>] [--cleanup=<mode>] [--[no-]status]
	   [-i | -o] [-S[<keyid>]] [--] [<file>...]",
                @"Stores the current contents of the index in a new commit along with a log message from the user describing the changes.


The content to be added can be specified in several ways:


by using git add to incrementally ""add"" changes to the index before using the commit command (Note: even modified files must be ""added"""),
            new GitCommand("config",
                "Get and set repository or global options",
                @"git config [<file-option>] [type] [--show-origin] [-z|--null] name [value [value_regex]]
git config [<file-option>] [type] --add name value
git config [<file-option>] [type] --replace-all name value [value_regex]
git config [<file-option>] [type] [--show-origin] [-z|--null] --get name [value_regex]
git config [<file-option>] [type] [--show-origin] [-z|--null] --get-all name [value_regex]
git config [<file-option>] [type] [--show-origin] [-z|--null] [--name-only] --get-regexp name_regex [value_regex]
git config [<file-option>] [type] [-z|--null] --get-urlmatch name URL
git config [<file-option>] --unset name [value_regex]
git config [<file-option>] --unset-all name [value_regex]
git config [<file-option>] --rename-section old_name new_name
git config [<file-option>] --remove-section name
git config [<file-option>] [--show-origin] [-z|--null] [--name-only] -l | --list
git config [<file-option>] --get-color name [default]
git config [<file-option>] --get-colorbool name [stdout-is-tty]
git config [<file-option>] -e | --edit",
                @"You can query/set/replace/unset options with this command. The name is actually the section and the key separated by a dot, and the value will be escaped.


Multiple lines can be added to an option by using the --add option. If you want to update or unset an option which can occur on multiple lines, a POSIX regexp value_regex needs to be given. Only the existing values that match the regexp are updated or unset. If you want to handle the lines that do not match the regex, just prepend a single exclamation mark in front (see also EXAMPLES"),
            new GitCommand("describe",
                "Describe a commit using the most recent tag reachable from it",
                @"git describe [--all] [--tags] [--contains] [--abbrev=<n>] [<commit-ish>...]
git describe [--all] [--tags] [--contains] [--abbrev=<n>] --dirty[=<mark>]",
                @"The command finds the most recent tag that is reachable from a commit. If the tag points to the commit, then only the tag is shown. Otherwise, it suffixes the tag name with the number of additional commits on top of the tagged object and the abbreviated object name of the most recent commi"),
            new GitCommand("diff",
                "Show changes between commits, commit and working tree, etc",
                @"git diff [options] [<commit>] [--] [<path>...]
git diff [options] --cached [<commit>] [--] [<path>...]
git diff [options] <commit> <commit> [--] [<path>...]
git diff [options] <blob> <blob>
git diff [options] [--no-index] [--] <path> <path>",
                @"Show changes between the working tree and the index or a tree, changes between the index and a tree, changes between two trees, changes between two blob objects, or changes between two files on disk."),
            new GitCommand("difftool",
                "Show changes using common diff tools",
                @"git difftool [<options>] [<commit> [<commit>]] [--] [<path>...]",
                @"git difftool is a Git command that allows you to compare and edit files between revisions using common diff tools. git difftool is a frontend to git diff and accepts the same options and arguments. See git-diff[1]."),
            new GitCommand("fetch",
                "Download objects and refs from another repository",
                @"git fetch [<options>] [<repository> [<refspec>...]]
git fetch [<options>] <group>
git fetch --multiple [<options>] [(<repository> | <group>)...]
git fetch --all [<options>]",
                @"Fetch branches and/or tags (collectively, ""refs"") from one or more other repositories, along with the objects necessary to complete their histories. Remote-tracking branches are updated (see the description of <refspec> below for ways to control this behavior"),
            new GitCommand("format-patch",
                "Prepare patches for e-mail submission",
                @"git format-patch [-k] [(-o|--output-directory) <dir> | --stdout]
		   [--no-thread | --thread[=<style>]]
		   [(--attach|--inline)[=<boundary>] | --no-attach]
		   [-s | --signoff]
		   [--signature=<signature> | --no-signature]
		   [--signature-file=<file>]
		   [-n | --numbered | -N | --no-numbered]
		   [--start-number <n>] [--numbered-files]
		   [--in-reply-to=Message-Id] [--suffix=.<sfx>]
		   [--ignore-if-in-upstream]
		   [--rfc] [--subject-prefix=Subject-Prefix]
		   [(--reroll-count|-v) <n>]
		   [--to=<email>] [--cc=<email>]
		   [--[no-]cover-letter] [--quiet] [--notes[=<ref>]]
		   [<common diff options>]
		   [ <since> | <revision range> ]",
                @"Prepare each commit with its patch in one file per commit, formatted to resemble UNIX mailbox format. The output of this command is convenient for e-mail submission or for use with git am.


There are two ways to specify which commits to operate o"),
            new GitCommand("gc",
                "Cleanup unnecessary files and optimize the local repository",
                @"git gc [--aggressive] [--auto] [--quiet] [--prune=<date> | --no-prune] [--force]",
                @"Runs a number of housekeeping tasks within the current repository, such as compressing file revisions (to reduce disk space and increase performance) and removing unreachable objects which may have been created from prior invocations of git ad"),
            new GitCommand("grep",
                "Print lines matching a pattern",
                @"git grep [-a | --text] [-I] [--textconv] [-i | --ignore-case] [-w | --word-regexp]
	   [-v | --invert-match] [-h|-H] [--full-name]
	   [-E | --extended-regexp] [-G | --basic-regexp]
	   [-P | --perl-regexp]
	   [-F | --fixed-strings] [-n | --line-number]
	   [-l | --files-with-matches] [-L | --files-without-match]
	   [(-O | --open-files-in-pager) [<pager>]]
	   [-z | --null]
	   [-c | --count] [--all-match] [-q | --quiet]
	   [--max-depth <depth>]
	   [--color[=<when>] | --no-color]
	   [--break] [--heading] [-p | --show-function]
	   [-A <post-context>] [-B <pre-context>] [-C <context>]
	   [-W | --function-context]
	   [--threads <num>]
	   [-f <file>] [-e] <pattern>
	   [--and|--or|--not|(|)|-e <pattern>...]
	   [ [--[no-]exclude-standard] [--cached | --no-index | --untracked] | <tree>...]
	   [--] [<pathspec>...]",
                @"Look for specified patterns in the tracked files in the work tree, blobs registered in the index file, or blobs in given tree objects. Patterns are lists of one or more search expressions separated by newline characters. An empty string as search expression matches all lines."),
            new GitCommand("gui",
                "A portable graphical interface to Git",
                @"git gui [<command>] [arguments]",
                @"A Tcl/Tk based graphical user interface to Git. git gui focuses on allowing users to make changes to their repository by making new commits, amending existing ones, creating branches, performing local merges, and fetching/pushing to remote repositorie"),
            new GitCommand("help",
                "Display help information about Git",
                @"git help [-a|--all] [-g|--guide]
	   [-i|--info|-m|--man|-w|--web] [COMMAND|GUIDE]",
                @"With no options and no COMMAND or GUIDE given, the synopsis of the git command and a list of the most commonly used Git commands are printed on the standard output.


If the option --all or -a is given, all available commands are printed on the standard outpu"),
            new GitCommand("init",
                "Create an empty Git repository or reinitialize an existing one",
                @"git init [-q | --quiet] [--bare] [--template=<template_directory>]
	  [--separate-git-dir <git dir>]
	  [--shared[=<permissions>]] [directory]",
                @"This command creates an empty Git repository - basically a .git directory with subdirectories for objects, refs/heads, refs/tags, and template files. An initial HEAD file that references the HEAD of the master branch is also create"),
            new GitCommand("instaweb",
                "Instantly browse your working repository in gitweb",
                @"git instaweb [--local] [--httpd=<httpd>] [--port=<port>]
               [--browser=<browser>]
git instaweb [--start] [--stop] [--restart]",
                @"A simple script to set up gitweb and a web server for browsing the local repository."),
            new GitCommand("log",
                "Show commit logs",
                @"git log [<options>] [<revision range>] [[\--] <path>...]",
                @"Shows the commit logs.


The command takes options applicable to the git rev-list command to control what is shown and how, and options applicable to the git diff-* commands to control how the changes each commit introduces are shown."),
            new GitCommand("merge",
                "Join two or more development histories together",
                @"git merge [-n] [--stat] [--no-commit] [--squash] [--[no-]edit]
	[-s <strategy>] [-X <strategy-option>] [-S[<keyid>]]
	[--[no-]allow-unrelated-histories]
	[--[no-]rerere-autoupdate] [-m <msg>] [<commit>...]
git merge <msg> HEAD <commit>...
git merge --abort",
                @"Incorporates changes from the named commits (since the time their histories diverged from the current branch) into the current branch. This command is used by git pull to incorporate changes from another repository and can be used by hand to merge changes from one branch into anothe"),
            new GitCommand("mergetool",
                "Run merge conflict resolution tools to resolve merge conflicts",
                @"git mergetool [--tool=<tool>] [-y | --[no-]prompt] [<file>...]",
                @"Use git mergetool to run one of several merge utilities to resolve merge conflicts. It is typically run after git merge.


If one or more <file> parameters are given, the merge tool program will be run to resolve differences on each file (skipping those without conflicts). Specifying a directory will include all unresolved files in that path. If no <file> names are specified, git mergetool will run the merge tool program on every file with merge conflicts."),
            new GitCommand("mv",
                "Move or rename a file, a directory, or a symlink",
                @"git mv <options>... <args>...",
                @"Move or rename a file, directory or symlink.


git mv [-v] [-f] [-n] [-k] <source> <destination>
git mv [-v] [-f] [-n] [-k] <source> ... <destination directory>


In the first form, it renames <source>, which must exist and be either a file, symlink or directory, to <destination>. In the second form, the last argument has to be an existing directory; the given sources will be moved into this director"),
            new GitCommand("notes",
                "Add or inspect object notes",
                @"git notes [list [<object>]]
git notes add [-f] [--allow-empty] [-F <file> | -m <msg> | (-c | -C) <object>] [<object>]
git notes copy [-f] ( --stdin | <from-object> <to-object> )
git notes append [--allow-empty] [-F <file> | -m <msg> | (-c | -C) <object>] [<object>]
git notes edit [--allow-empty] [<object>]
git notes show [<object>]
git notes merge [-v | -q] [-s <strategy> ] <notes-ref>
git notes merge --commit [-v | -q]
git notes merge --abort [-v | -q]
git notes remove [--ignore-missing] [--stdin] [<object>...]
git notes prune [-n | -v]
git notes get-ref",
                @"Adds, removes, or reads notes attached to objects, without touching the objects themselves.


By default, notes are saved to and read from refs/notes/commits, but this default can be overridden. See the OPTIONS, CONFIGURATION, and ENVIRONMENT sections below. If this ref does not exist, it will be quietly created when it is first needed to store a not"),
            new GitCommand("prune",
                "Prune all unreachable objects from the object database",
                @"git prune [-n] [-v] [--expire <expire>] [--] [<head>...]",
                @"Note
In most cases, users should run git gc, which calls git prune. See the section ""NOTES"", below.


This runs git fsck --unreachable using all the refs available in refs/, optionally with additional set of objects specified on the command line, and prunes all unpacked objects unreachable from any of these head objects from the object database. In addition, it prunes the unpacked objects that are also found in packs by running git prune-packed. It also removes entries from .git/shallow that are not reachable by any re"),
            new GitCommand("pull",
                "Fetch from and integrate with another repository or a local branch",
                @"git pull [options] [<repository> [<refspec>...]]",
                @"Incorporates changes from a remote repository into the current branch. In its default mode, git pull is shorthand for git fetch followed by git merge FETCH_HEAD.


More precisely, git pull runs git fetch with the given parameters and calls git merge to merge the retrieved branch heads into the current branch. With --rebase, it runs git rebase instead of git merg"),
            new GitCommand("push",
                "Update remote refs along with associated objects",
                @"git push [--all | --mirror | --tags] [--follow-tags] [--atomic] [-n | --dry-run] [--receive-pack=<git-receive-pack>]
	   [--repo=<repository>] [-f | --force] [-d | --delete] [--prune] [-v | --verbose]
	   [-u | --set-upstream] [--push-option=<string>]
	   [--[no-]signed|--sign=(true|false|if-asked)]
	   [--force-with-lease[=<refname>[:<expect>]]]
	   [--no-verify] [<repository> [<refspec>...]]",
                @"Updates remote refs using local refs, while sending objects necessary to complete the given refs.


You can make interesting things happen to a repository every time you push into it, by setting up hooks there. See documentation for git-receive-pack[1"),
            new GitCommand("rebase",
                "Reapply commits on top of another base tip",
                @"git rebase [-i | --interactive] [options] [--exec <cmd>] [--onto <newbase>]
	[<upstream> [<branch>]]
git rebase [-i | --interactive] [options] [--exec <cmd>] [--onto <newbase>]
	--root [<branch>]
git rebase --continue | --skip | --abort | --edit-todo",
                @"If <branch> is specified, git rebase will perform an automatic git checkout <branch> before doing anything else. Otherwise it remains on the current branch.


If <upstream> is not specified, the upstream configured in branch.<name>.remote and branch.<name>.merge options will be used (see git-config[1] for details) and the --fork-point option is assumed. If you are currently not on any branch or if the current branch does not have a configured upstream, the rebase will abor"),
            new GitCommand("reflog",
                "Manage reflog information",
                @"git reflog <subcommand> <options>",
                @"The command takes various subcommands, and different options depending on the subcommand:

git reflog [show] [log-options] [<ref>]
git reflog expire [--expire=<time>] [--expire-unreachable=<time>]
	[--rewrite] [--updateref] [--stale-fi"),
            new GitCommand("remote",
                "Manage set of tracked repositories",
                @"git remote [-v | --verbose]
git remote add [-t <branch>] [-m <master>] [-f] [--[no-]tags] [--mirror=<fetch|push>] <name> <url>
git remote rename <old> <new>
git remote remove <name>
git remote set-head <name> (-a | --auto | -d | --delete | <branch>)
git remote set-branches [--add] <name> <branch>...
git remote get-url [--push] [--all] <name>
git remote set-url [--push] <name> <newurl> [<oldurl>]
git remote set-url --add [--push] <name> <newurl>
git remote set-url --delete [--push] <name> <url>
git remote [-v | --verbose] show [-n] <name>...
git remote prune [-n | --dry-run] <name>...
git remote [-v | --verbose] update [-p | --prune] [(<group> | <remote>)...]",
                @"Manage the set of repositories (""remotes"") whose branches you track."),
            new GitCommand("rerere",
                "Reuse recorded resolution of conflicted merges",
                @"git rerere [clear|forget <pathspec>|diff|remaining|status|gc]",
                @"In a workflow employing relatively long lived topic branches, the developer sometimes needs to resolve the same conflicts over and over again until the topic branches are done (either merged to the ""release"" branch, or sent out and accepted upstream"),
            new GitCommand("reset",
                "Reset current HEAD to the specified state",
                @"git reset [-q] [<tree-ish>] [--] <paths>...
git reset (--patch | -p) [<tree-ish>] [--] [<paths>...]
git reset [--soft | --mixed [-N] | --hard | --merge | --keep] [-q] [<commit>]",
                @"In the first and second form, copy entries from <tree-ish> to the index. In the third form, set the current branch head (HEAD) to <commit>, optionally modifying index and working tree to match. The <tree-ish>/<commit> defaults to HEAD in all form"),
            new GitCommand("revert",
                "Revert some existing commits",
                @"git revert [--[no-]edit] [-n] [-m parent-number] [-s] [-S[<keyid>]] <commit>...
git revert --continue
git revert --quit
git revert --abort",
                @"Given one or more existing commits, revert the changes that the related patches introduce, and record some new commits that record them. This requires your working tree to be clean (no modifications from the HEAD commit"),
            new GitCommand("rm",
                "Remove files from the working tree and from the index",
                @"git rm [-f | --force] [-n] [-r] [--cached] [--ignore-unmatch] [--quiet] [--] <file>...",
                @"Remove files from the index, or from the working tree and the index. git rm will not remove a file from just your working directory. (There is no option to remove a file only from the working tree and yet keep it in the index; use /bin/rm if you want to do that.) The files being removed have to be identical to the tip of the branch, and no updates to their contents can be staged in the index, though that default behavior can be overridden with the -f option. When --cached is given, the staged content has to match either the tip of the branch or the file on disk, allowing the file to be removed from just the index."),
            new GitCommand("shortlog",
                "Summarize git log output",
                @"git log --pretty=short | git shortlog [<options>]
git shortlog [<options>] [<revision range>] [[\--] <path>...]",
                @"Summarizes git log output in a format suitable for inclusion in release announcements. Each commit will be grouped by author and title.


Additionally, ""[PATCH]"" will be stripped from the commit descriptio"),
            new GitCommand("show",
                "Show various types of objects",
                @"git show [options] <object>...",
                @"Shows one or more objects (blobs, trees, tags and commits).


For commits it shows the log message and textual diff. It also presents the merge commit in a special format as produced by git diff-tree --c"),
            new GitCommand("stash",
                "Stash the changes in a dirty working directory away",
                @"git stash list [<options>]
git stash show [<stash>]
git stash drop [-q|--quiet] [<stash>]
git stash ( pop | apply ) [--index] [-q|--quiet] [<stash>]
git stash branch <branchname> [<stash>]
git stash [save [-p|--patch] [-k|--[no-]keep-index] [-q|--quiet]
	     [-u|--include-untracked] [-a|--all] [<message>]]
git stash clear
git stash create [<message>]
git stash store [-m|--message <message>] [-q|--quiet] <commit>",
                @"Use git stash when you want to record the current state of the working directory and the index, but want to go back to a clean working directory. The command saves your local modifications away and reverts the working directory to match the HEAD commi"),
            new GitCommand("status",
                "Show the working tree status",
                @"git status [<options>...] [--] [<pathspec>...]",
                @"Displays paths that have differences between the index file and the current HEAD commit, paths that have differences between the working tree and the index file, and paths in the working tree that are not tracked by Git (and are not ignored by gitignore[5]). The first are what you would commit by running git commit; the second and third are what you could commit by running git add before running git commit."),
            new GitCommand("submodule",
                "Initialize, update or inspect submodules",
                @"git submodule [--quiet] add [-b <branch>] [-f|--force] [--name <name>]
	      [--reference <repository>] [--depth <depth>] [--] <repository> [<path>]
git submodule [--quiet] status [--cached] [--recursive] [--] [<path>...]
git submodule [--quiet] init [--] [<path>...]
git submodule [--quiet] deinit [-f|--force] (--all|[--] <path>...)
git submodule [--quiet] update [--init] [--remote] [-N|--no-fetch]
	      [--[no-]recommend-shallow] [-f|--force] [--rebase|--merge]
	      [--reference <repository>] [--depth <depth>] [--recursive]
	      [--jobs <n>] [--] [<path>...]
git submodule [--quiet] summary [--cached|--files] [(-n|--summary-limit) <n>]
	      [commit] [--] [<path>...]
git submodule [--quiet] foreach [--recursive] <command>
git submodule [--quiet] sync [--recursive] [--] [<path>...]",
                @"Inspects, updates and manages submodules.


A submodule allows you to keep another Git repository in a subdirectory of your repository. The other repository has its own history, which does not interfere with the history of the current repository. This can be used to have external dependencies such as third party libraries for exampl"),
            new GitCommand("svn",
                "Bidirectional operation between a Subversion repository and Git",
                @"git svn <command> [options] [arguments]",
                @"git svn is a simple conduit for changesets between Subversion and Git. It provides a bidirectional flow of changes between a Subversion and a Git repository.


git svn can track a standard Subversion repository, following the common ""trunk/branches/tags"" layout, with the --stdlayout option. It can also follow branches and tags in any layout with the -T/-t/-b options (see options to init below, and also the clone command"),
            new GitCommand("tag",
                "Create, list, delete or verify a tag object signed with GPG",
                @"git tag [-a | -s | -u <keyid>] [-f] [-m <msg> | -F <file>]
	<tagname> [<commit> | <object>]
git tag -d <tagname>...
git tag [-n[<num>]] -l [--contains <commit>] [--points-at <object>]
	[--column[=<options>] | --no-column] [--create-reflog] [--sort=<key>]
	[--format=<format>] [--[no-]merged [<commit>]] [<pattern>...]
git tag -v <tagname>...",
                @"Add a tag reference in refs/tags/, unless -d/-l/-v is given to delete, list or verify tags.


Unless -f is given, the named tag must not yet exist.


If one of -a, -s, or -u <keyid> is passed, the command creates a tag object, and requires a tag message. Unless -m <msg> or -F <file> is given, an editor is started for the user to type in the tag messag"),

            new GitCommand("restore", "Restore working tree files",
                @"git restore [<options>] [--source=<tree>] [--staged] [--worktree] [--] <pathspec>…​
git restore [<options>] [--source=<tree>] [--staged] [--worktree] --pathspec-from-file=<file> [--pathspec-file-nul]
git restore (-p|--patch) [<options>] [--source=<tree>] [--staged] [--worktree] [--] [<pathspec>…​]",
                @"Restore specified paths in the working tree with some contents from a restore source.
If a path is tracked but does not exist in the restore source, it will be removed to match the source.
The command can also be used to restore the content in the index with --staged, or restore both the working tree and the index with --staged --worktree."),
            #endregion
        };

        public string Name { get; }
        public string CommandDesc { get; }

        public string Synopsis { get; }

        public string Description { get; }

        public GitCommand(string name, string commandDesc, string synopsis, string description)
        {
            Name = name;
            CommandDesc = commandDesc;
            Synopsis = synopsis;
            Description = description;
        }

        public static GitCommandOption[] GetOptions(string name, bool resolveAliases = true)
        {
            return name switch
            {
                "add" => new[]
                {
                    new GitCommandOption("--", @"--",
                        @"This option can be used to separate command-line options from the list of files, (useful when filenames might be mistaken for command-line options)."),
                    new GitCommandOption("-A", @"-A",
                        @"Update the index not only where the working tree has a file matching <pathspec> but also where the index already has an entry. This adds, modifies, and removes index entries to match the working tree.
If no <pathspec> is given when -A option is used, all files in the entire working tree are updated (old versions of Git used to limit the update to the current directory and its subdirectories)."),
                    new GitCommandOption("--all", @"--all",
                        @"Update the index not only where the working tree has a file matching <pathspec> but also where the index already has an entry. This adds, modifies, and removes index entries to match the working tree.
If no <pathspec> is given when -A option is used, all files in the entire working tree are updated (old versions of Git used to limit the update to the current directory and its subdirectories)."),
                    new GitCommandOption("--chmod=(+|-)x", @"--chmod=(+|-)x",
                        @"Override the executable bit of the added files. The executable bit is only changed in the index, the files on disk are left unchanged."),
                    new GitCommandOption("--dry-run", @"--dry-run", @"Don't actually add the file(s), just show if they exist and/or will be ignored."), new GitCommandOption("-e", @"-e",
                        @"Open the diff vs. the index in an editor and let the user edit it. After the editor was closed, adjust the hunk headers and apply the patch to the index.
The intent of this option is to pick and choose lines of the patch to apply, or even to modify the contents of lines to be staged. This can be quicker and more flexible than using the interactive hunk selector. However, it is easy to confuse oneself and create a patch that does not apply to the index. See EDITING PATCHES below."),
                    new GitCommandOption("--edit", @"--edit",
                        @"Open the diff vs. the index in an editor and let the user edit it. After the editor was closed, adjust the hunk headers and apply the patch to the index.
The intent of this option is to pick and choose lines of the patch to apply, or even to modify the contents of lines to be staged. This can be quicker and more flexible than using the interactive hunk selector. However, it is easy to confuse oneself and create a patch that does not apply to the index. See EDITING PATCHES below."),
                    new GitCommandOption("-f", @"-f", @"Allow adding otherwise ignored files."), new GitCommandOption("--force", @"--force", @"Allow adding otherwise ignored files."),
                    new GitCommandOption("-i", @"-i",
                        @"Add modified contents in the working tree interactively to the index. Optional path arguments may be supplied to limit operation to a subset of the working tree. See 'Interactive mode' for details."),
                    new GitCommandOption("--ignore-errors", @"--ignore-errors",
                        @"If some files could not be added because of errors indexing them, do not abort the operation, but continue adding the others. The command shall still exit with non-zero status. The configuration variable add.ignoreErrors can be set to true to make this the default behaviour."),
                    new GitCommandOption("--ignore-missing", @"--ignore-missing",
                        @"This option can only be used together with --dry-run. By using this option the user can check if any of the given files would be ignored, no matter if they are already present in the work tree or not."),
                    new GitCommandOption("--ignore-removal", @"--ignore-removal",
                        @"Update the index by adding new files that are unknown to the index and files modified in the working tree, but ignore files that have been removed from the working tree. This option is a no-op when no <pathspec> is used.
This option is primarily to help users who are used to older versions of Git, whose ""git add <pathspec>..."" was a synonym for ""git add --no-all <pathspec>..."", i.e. ignored removed files."),
                    new GitCommandOption("--intent-to-add", @"--intent-to-add",
                        @"Record only the fact that the path will be added later. An entry for the path is placed in the index with no content. This is useful for, among other things, showing the unstaged content of such files with git diff and committing them with git commit -a."),
                    new GitCommandOption("--interactive", @"--interactive",
                        @"Add modified contents in the working tree interactively to the index. Optional path arguments may be supplied to limit operation to a subset of the working tree. See 'Interactive mode' for details."),
                    new GitCommandOption("-N", @"-N",
                        @"Record only the fact that the path will be added later. An entry for the path is placed in the index with no content. This is useful for, among other things, showing the unstaged content of such files with git diff and committing them with git commit -a."),
                    new GitCommandOption("-n", @"-n", @"Don't actually add the file(s), just show if they exist and/or will be ignored."), new GitCommandOption("--no-all", @"--no-all",
                        @"Update the index by adding new files that are unknown to the index and files modified in the working tree, but ignore files that have been removed from the working tree. This option is a no-op when no <pathspec> is used.
This option is primarily to help users who are used to older versions of Git, whose ""git add <pathspec>..."" was a synonym for ""git add --no-all <pathspec>..."", i.e. ignored removed files."),
                    new GitCommandOption("--no-ignore-removal", @"--no-ignore-removal",
                        @"Update the index not only where the working tree has a file matching <pathspec> but also where the index already has an entry. This adds, modifies, and removes index entries to match the working tree.
If no <pathspec> is given when -A option is used, all files in the entire working tree are updated (old versions of Git used to limit the update to the current directory and its subdirectories)."),
                    new GitCommandOption("-p", @"-p",
                        @"Interactively choose hunks of patch between the index and the work tree and add them to the index. This gives the user a chance to review the difference before adding modified contents to the index.
This effectively runs add --interactive, but bypasses the initial command menu and directly jumps to the patch subcommand. See 'Interactive mode' for details."),
                    new GitCommandOption("--patch", @"--patch",
                        @"Interactively choose hunks of patch between the index and the work tree and add them to the index. This gives the user a chance to review the difference before adding modified contents to the index.
This effectively runs add --interactive, but bypasses the initial command menu and directly jumps to the patch subcommand. See 'Interactive mode' for details."),
                    new GitCommandOption("--refresh", @"--refresh", @"Don't add the file(s), but only refresh their stat() information in the index."), new GitCommandOption("-u", @"-u",
                        @"Update the index just where it already has an entry matching <pathspec>. This removes as well as modifies index entries to match the working tree, but adds no new files.
If no <pathspec> is given when -u option is used, all tracked files in the entire working tree are updated (old versions of Git used to limit the update to the current directory and its subdirectories)."),
                    new GitCommandOption("--update", @"--update",
                        @"Update the index just where it already has an entry matching <pathspec>. This removes as well as modifies index entries to match the working tree, but adds no new files.
If no <pathspec> is given when -u option is used, all tracked files in the entire working tree are updated (old versions of Git used to limit the update to the current directory and its subdirectories)."),
                    new GitCommandOption("-v", @"-v", @"Be verbose."), new GitCommandOption("--verbose", @"--verbose", @"Be verbose.")
                },
                "am" => new[]
                {
                    new GitCommandOption("-3", @"-3",
                        @"When the patch does not apply cleanly, fall back on 3-way merge if the patch records the identity of blobs it is supposed to apply to and we have those blobs available locally. --no-3way can be used to override am.threeWay configuration variable. For more information, see am.threeWay in git-config[1]."),
                    new GitCommandOption("--3way", @"--3way",
                        @"When the patch does not apply cleanly, fall back on 3-way merge if the patch records the identity of blobs it is supposed to apply to and we have those blobs available locally. --no-3way can be used to override am.threeWay configuration variable. For more information, see am.threeWay in git-config[1]."),
                    new GitCommandOption("--abort", @"--abort", @"Restore the original branch and abort the patching operation."),
                    new GitCommandOption("-c", @"-c",
                        @"Remove everything in body before a scissors line (see git-mailinfo[1]). Can be activated by default using the mailinfo.scissors configuration variable."),
                    new GitCommandOption("-C", @"-C<n>", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch."),
                    new GitCommandOption("--committer-date-is-author-date", @"--committer-date-is-author-date",
                        @"By default the command records the date from the e-mail message as the commit author date, and uses the time of commit creation as the committer date. This allows the user to lie about the committer date by using the same value as the author date."),
                    new GitCommandOption("--continue", @"--continue",
                        @"After a patch failure (e.g. attempting to apply conflicting patch), the user has applied it by hand and the index file stores the result of the application. Make a commit using the authorship and commit log extracted from the e-mail message and the current index file, and continue."),
                    new GitCommandOption("--directory=", @"--directory=<dir>", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch."),
                    new GitCommandOption("--exclude=", @"--exclude=<path>", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch."),
                    new GitCommandOption("--gpg-sign", @"--gpg-sign[=<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("-i", @"-i", @"Run interactively."),
                    new GitCommandOption("--ignore-date", @"--ignore-date",
                        @"By default the command records the date from the e-mail message as the commit author date, and uses the time of commit creation as the committer date. This allows the user to lie about the author date by using the same value as the committer date."),
                    new GitCommandOption("--ignore-space-change", @"--ignore-space-change", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch."),
                    new GitCommandOption("--ignore-whitespace", @"--ignore-whitespace", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch."),
                    new GitCommandOption("--include=", @"--include=<path>", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch."),
                    new GitCommandOption("--interactive", @"--interactive", @"Run interactively."), new GitCommandOption("-k", @"-k", @"Pass -k flag to git mailinfo (see git-mailinfo[1])."),
                    new GitCommandOption("--keep", @"--keep", @"Pass -k flag to git mailinfo (see git-mailinfo[1])."),
                    new GitCommandOption("--keep-cr", @"--keep-cr",
                        @"With --keep-cr, call git mailsplit (see git-mailsplit[1]) with the same option, to prevent it from stripping CR at the end of lines. am.keepcr configuration variable can be used to specify the default behaviour. --no-keep-cr is useful to override am.keepcr."),
                    new GitCommandOption("--keep-non-patch", @"--keep-non-patch", @"Pass -b flag to git mailinfo (see git-mailinfo[1])."),
                    new GitCommandOption("-m", @"-m",
                        @"Pass the -m flag to git mailinfo (see git-mailinfo[1]), so that the Message-ID header is added to the commit message. The am.messageid configuration variable can be used to specify the default behaviour."),
                    new GitCommandOption("--message-id", @"--message-id",
                        @"Pass the -m flag to git mailinfo (see git-mailinfo[1]), so that the Message-ID header is added to the commit message. The am.messageid configuration variable can be used to specify the default behaviour."),
                    new GitCommandOption("--no-3way", @"--no-3way",
                        @"When the patch does not apply cleanly, fall back on 3-way merge if the patch records the identity of blobs it is supposed to apply to and we have those blobs available locally. --no-3way can be used to override am.threeWay configuration variable. For more information, see am.threeWay in git-config[1]."),
                    new GitCommandOption("--no-keep-cr", @"--no-keep-cr",
                        @"With --keep-cr, call git mailsplit (see git-mailsplit[1]) with the same option, to prevent it from stripping CR at the end of lines. am.keepcr configuration variable can be used to specify the default behaviour. --no-keep-cr is useful to override am.keepcr."),
                    new GitCommandOption("--no-message-id", @"--no-message-id", @"Do not add the Message-ID header to the commit message. no-message-id is useful to override am.messageid."),
                    new GitCommandOption("--no-scissors", @"--no-scissors", @"Ignore scissors lines (see git-mailinfo[1])."),
                    new GitCommandOption("--no-utf8", @"--no-utf8", @"Pass -n flag to git mailinfo (see git-mailinfo[1])."),
                    new GitCommandOption("-p", @"-p<n>", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch."),
                    new GitCommandOption("--patch-format", @"--patch-format",
                        @"By default the command will try to detect the patch format automatically. This option allows the user to bypass the automatic detection and specify the patch format that the patch(es) should be interpreted as. Valid formats are mbox, mboxrd, stgit, stgit-series and hg."),
                    new GitCommandOption("-q", @"-q", @"Be quiet. Only print error messages."), new GitCommandOption("--quiet", @"--quiet", @"Be quiet. Only print error messages."),
                    new GitCommandOption("-r", @"-r",
                        @"After a patch failure (e.g. attempting to apply conflicting patch), the user has applied it by hand and the index file stores the result of the application. Make a commit using the authorship and commit log extracted from the e-mail message and the current index file, and continue."),
                    new GitCommandOption("--reject", @"--reject", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch."),
                    new GitCommandOption("--resolved", @"--resolved",
                        @"After a patch failure (e.g. attempting to apply conflicting patch), the user has applied it by hand and the index file stores the result of the application. Make a commit using the authorship and commit log extracted from the e-mail message and the current index file, and continue."),
                    new GitCommandOption("--resolvemsg=", @"--resolvemsg=<msg>",
                        @"When a patch failure occurs, <msg> will be printed to the screen before exiting. This overrides the standard message informing you to use --continue or --skip to handle the failure. This is solely for internal use between git rebase and git am."),
                    new GitCommandOption("-S", @"-S[<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("-s", @"-s",
                        @"Add a Signed-off-by: line to the commit message, using the committer identity of yourself. See the signoff option in git-commit[1] for more information."),
                    new GitCommandOption("--scissors", @"--scissors",
                        @"Remove everything in body before a scissors line (see git-mailinfo[1]). Can be activated by default using the mailinfo.scissors configuration variable."),
                    new GitCommandOption("--signoff", @"--signoff",
                        @"Add a Signed-off-by: line to the commit message, using the committer identity of yourself. See the signoff option in git-commit[1] for more information."),
                    new GitCommandOption("--skip", @"--skip", @"Skip the current patch. This is only meaningful when restarting an aborted patch."), new GitCommandOption("-u", @"-u",
                        @"Pass -u flag to git mailinfo (see git-mailinfo[1]). The proposed commit log message taken from the e-mail is re-coded into UTF-8 encoding (configuration variable i18n.commitencoding can be used to specify project''s preferred encoding if it is not UTF-8).
This was optional in prior versions of git, but now it is the default. You can use --no-utf8 to override this."),
                    new GitCommandOption("--utf8", @"--utf8",
                        @"Pass -u flag to git mailinfo (see git-mailinfo[1]). The proposed commit log message taken from the e-mail is re-coded into UTF-8 encoding (configuration variable i18n.commitencoding can be used to specify project''s preferred encoding if it is not UTF-8).
This was optional in prior versions of git, but now it is the default. You can use --no-utf8 to override this."),
                    new GitCommandOption("--whitespace", @"--whitespace=<option>", @"These flags are passed to the git apply (see git-apply[1]) program that applies the patch.")
                },
                "annotate" => new[]
                {
                    new GitCommandOption("-b", @"-b", @"Show blank SHA-1 for boundary commits. This can also be controlled via the blame.blankboundary config option."), new GitCommandOption(
                        "-C|<num>|", @"-C|<num>|",
                        @"In addition to -M, detect lines moved or copied from other files that were modified in the same commit. This is useful when you reorganize your program and move code around across files. When this option is given twice, the command additionally looks for copies from other files in the commit that creates the file. When this option is given three times, the command additionally looks for copies from other files in any commit.
<num> is optional but it is the lower bound on the number of alphanumeric characters that Git must detect as moving/copying between files for it to associate those lines with the parent commit. And the default value is 40. If there are more than one -C options given, the <num> argument of the last -C will take effect."),
                    new GitCommandOption("--compaction-heuristic", @"--compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--contents", @"--contents <file>",
                        @"When <rev> is not specified, the command annotates the changes starting backwards from the working tree copy. This flag makes the command pretend as if the working tree copy has the contents of the named file (specify - to make the command read from the standard input)."),
                    new GitCommandOption("--date", @"--date <format>",
                        @"Specifies the format used to output dates. If --date is not provided, the value of the blame.date config variable is used. If the blame.date config variable is also not set, the iso format is used. For supported values, see the discussion of the --date option at git-log[1]."),
                    new GitCommandOption("--encoding", @"--encoding=<encoding>",
                        @"Specifies the encoding used to output author names and commit summaries. Setting it to none makes blame output unconverted data. For more information see the discussion about encoding in the git-log[1] manual page."),
                    new GitCommandOption("-h", @"-h", @"Show help message."),
                    new GitCommandOption("--incremental", @"--incremental", @"Show the result incrementally in a format designed for machine consumption."),
                    new GitCommandOption("--indent-heuristic", @"--indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("-l", @"-l", @"Show long rev (Default: off)."), new GitCommandOption("-L ", @"-L <start>,<end>",
                        @"Annotate only the given line range. May be specified multiple times. Overlapping ranges are allowed.
<start> and <end> are optional. '-L <start>' or '-L <start>,' spans from <start> to end of file. '-L ,<end>' spans from start of file to <end>.
<start> and <end> can take one of these forms:
number
If <start> or <end> is a number, it specifies an absolute line number (lines count from 1).
/regex/
This form will use the first line matching the given POSIX regex. If <start> is a regex, it will search from the end of the previous -L range, if any, otherwise from the start of file. If <start> is '^/regex/', it will search from the start of file. If <end> is a regex, it will search starting at the line given by <start>.
+offset or -offset
This is only valid for <end> and will specify a number of lines before or after the line given by <start>.
If ':<funcname>' is given in place of <start> and <end>, it is a regular expression that denotes the range from the first funcname line that matches <funcname>, up to the next funcname line. ':<funcname>' searches from the end of the previous -L range, if any, otherwise from the start of file. '^:<funcname>' searches from the start of file."),
                    new GitCommandOption("-L :<funcname>", @"-L :<funcname>", @"Annotate only the given line range. May be specified multiple times. Overlapping ranges are allowed.
<start> and <end> are optional. '-L <start>' or '-L <start>,' spans from <start> to end of file. '-L ,<end>' spans from start of file to <end>.
<start> and <end> can take one of these forms:
number
If <start> or <end> is a number, it specifies an absolute line number (lines count from 1).
/regex/
This form will use the first line matching the given POSIX regex. If <start> is a regex, it will search from the end of the previous -L range, if any, otherwise from the start of file. If <start> is '^/regex/', it will search from the start of file. If <end> is a regex, it will search starting at the line given by <start>.
+offset or -offset
This is only valid for <end> and will specify a number of lines before or after the line given by <start>.
If ':<funcname>' is given in place of <start> and <end>, it is a regular expression that denotes the range from the first funcname line that matches <funcname>, up to the next funcname line. ':<funcname>' searches from the end of the previous -L range, if any, otherwise from the start of file. '^:<funcname>' searches from the start of file."),
                    new GitCommandOption("--line-porcelain", @"--line-porcelain",
                        @"Show the porcelain format, but output commit information for each line, not just the first time a commit is referenced. Implies --porcelain."),
                    new GitCommandOption("-M|<num>|", @"-M|<num>|",
                        @"Detect moved or copied lines within a file. When a commit moves or copies a block of lines (e.g. the original file has A and then B, and the commit changes it to B and then A), the traditional blame algorithm notices only half of the movement and typically blames the lines that were moved up (i.e. B) to the parent and assigns blame to the lines that were moved down (i.e. A) to the child commit. With this option, both groups of lines are blamed on the parent by running extra passes of inspection.
<num> is optional but it is the lower bound on the number of alphanumeric characters that Git must detect as moving/copying within a file for it to associate those lines with the parent commit. The default value is 20."),
                    new GitCommandOption("--no-compaction-heuristic", @"--no-compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-indent-heuristic", @"--no-indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-progress", @"--no-progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal. This flag enables progress reporting even if not attached to a terminal. Can''t use --progress together with --porcelain or --incremental."),
                    new GitCommandOption("-p", @"-p", @"Show in a format designed for machine consumption."),
                    new GitCommandOption("--porcelain", @"--porcelain", @"Show in a format designed for machine consumption."),
                    new GitCommandOption("--progress", @"--progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal. This flag enables progress reporting even if not attached to a terminal. Can''t use --progress together with --porcelain or --incremental."),
                    new GitCommandOption("--reverse ", @"--reverse <rev>..<rev>",
                        @"Walk history forward instead of backward. Instead of showing the revision in which a line appeared, this shows the last revision in which a line has existed. This requires a range of revision like START..END where the path to blame exists in START. git blame --reverse START is taken as git blame --reverse START..HEAD for convenience."),
                    new GitCommandOption("--root", @"--root", @"Do not treat root commits as boundaries. This can also be controlled via the blame.showRoot config option."),
                    new GitCommandOption("-S", @"-S <revs-file>", @"Use revisions from revs-file instead of calling git-rev-list[1]."),
                    new GitCommandOption("--show-stats", @"--show-stats", @"Include additional statistics at the end of blame output."),
                    new GitCommandOption("-t", @"-t", @"Show raw timestamp (Default: off).")
                },
                "archive" => new[]
                {
                    new GitCommandOption("-0", @"-0", @"Store the files instead of deflating them."),
                    new GitCommandOption("-9", @"-9", @"Highest and slowest compression level. You can specify any number from 1 to 9 to adjust compression speed and ratio."),
                    new GitCommandOption("--exec", @"--exec=<git-upload-archive>", @"Used with --remote to specify the path to the git-upload-archive on the remote side."),
                    new GitCommandOption("--format=", @"--format=<fmt>",
                        @"Format of the resulting archive: tar or zip. If this option is not given, and the output file is specified, the format is inferred from the filename if possible (e.g. writing to ""foo.zip"" makes the output to be in the zip format). Otherwise the output format is tar."),
                    new GitCommandOption("-l", @"-l", @"Show all available formats."), new GitCommandOption("--list", @"--list", @"Show all available formats."),
                    new GitCommandOption("-o", @"-o <file>", @"Write the archive to <file> instead of stdout."),
                    new GitCommandOption("--output", @"--output=<file>", @"Write the archive to <file> instead of stdout."),
                    new GitCommandOption("--prefix/", @"--prefix=<prefix>/", @"Prepend <prefix>/ to each filename in the archive."),
                    new GitCommandOption("--remote", @"--remote=<repo>",
                        @"Instead of making a tar archive from the local repository, retrieve a tar archive from a remote repository. Note that the remote repository may place restrictions on which sha1 expressions may be allowed in <tree-ish>. See git-upload-archive[1] for details."),
                    new GitCommandOption("-v", @"-v", @"Report progress to stderr."), new GitCommandOption("--verbose", @"--verbose", @"Report progress to stderr."),
                    new GitCommandOption("--worktree-attributes", @"--worktree-attributes", @"Look for attributes in .gitattributes files in the working tree as well (see ATTRIBUTES).")
                },
                "bisect" => System.Array.Empty<GitCommandOption>(),
                "blame" => new[]
                {
                    new GitCommandOption("--abbrev", @"--abbrev=<n>",
                        @"Instead of using the default 7+1 hexadecimal digits as the abbreviated object name, use <n>+1 digits. Note that 1 column is used for a caret to mark the boundary commit."),
                    new GitCommandOption("-b", @"-b", @"Show blank SHA-1 for boundary commits. This can also be controlled via the blame.blankboundary config option."),
                    new GitCommandOption("-c", @"-c", @"Use the same output mode as git-annotate[1] (Default: off)."), new GitCommandOption("-C|<num>|", @"-C|<num>|",
                        @"In addition to -M, detect lines moved or copied from other files that were modified in the same commit. This is useful when you reorganize your program and move code around across files. When this option is given twice, the command additionally looks for copies from other files in the commit that creates the file. When this option is given three times, the command additionally looks for copies from other files in any commit.
<num> is optional but it is the lower bound on the number of alphanumeric characters that Git must detect as moving/copying between files for it to associate those lines with the parent commit. And the default value is 40. If there are more than one -C options given, the <num> argument of the last -C will take effect."),
                    new GitCommandOption("--compaction-heuristic", @"--compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--contents", @"--contents <file>",
                        @"When <rev> is not specified, the command annotates the changes starting backwards from the working tree copy. This flag makes the command pretend as if the working tree copy has the contents of the named file (specify - to make the command read from the standard input)."),
                    new GitCommandOption("--date", @"--date <format>",
                        @"Specifies the format used to output dates. If --date is not provided, the value of the blame.date config variable is used. If the blame.date config variable is also not set, the iso format is used. For supported values, see the discussion of the --date option at git-log[1]."),
                    new GitCommandOption("-e", @"-e", @"Show the author email instead of author name (Default: off). This can also be controlled via the blame.showEmail config option."),
                    new GitCommandOption("--encoding=", @"--encoding=<encoding>",
                        @"Specifies the encoding used to output author names and commit summaries. Setting it to none makes blame output unconverted data. For more information see the discussion about encoding in the git-log[1] manual page."),
                    new GitCommandOption("-f", @"-f",
                        @"Show the filename in the original commit. By default the filename is shown if there is any line that came from a file with a different name, due to rename detection."),
                    new GitCommandOption("-h", @"-h", @"Show help message."),
                    new GitCommandOption("--incremental", @"--incremental", @"Show the result incrementally in a format designed for machine consumption."),
                    new GitCommandOption("--indent-heuristic", @"--indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("-l", @"-l", @"Show long rev (Default: off)."), new GitCommandOption("-L :<funcname>", @"-L :<funcname>",
                        @"Annotate only the given line range. May be specified multiple times. Overlapping ranges are allowed.
<start> and <end> are optional. '-L <start>' or '-L <start>,' spans from <start> to end of file. '-L ,<end>' spans from start of file to <end>.
<start> and <end> can take one of these forms:
number
If <start> or <end> is a number, it specifies an absolute line number (lines count from 1).
/regex/
This form will use the first line matching the given POSIX regex. If <start> is a regex, it will search from the end of the previous -L range, if any, otherwise from the start of file. If <start> is '^/regex/', it will search from the start of file. If <end> is a regex, it will search starting at the line given by <start>.
+offset or -offset
This is only valid for <end> and will specify a number of lines before or after the line given by <start>.
If ':<funcname>' is given in place of <start> and <end>, it is a regular expression that denotes the range from the first funcname line that matches <funcname>, up to the next funcname line. ':<funcname>' searches from the end of the previous -L range, if any, otherwise from the start of file. '^:<funcname>' searches from the start of file."),
                    new GitCommandOption("-L,<end>", @"-L <start>,<end>", @"Annotate only the given line range. May be specified multiple times. Overlapping ranges are allowed.
<start> and <end> are optional. '-L <start>' or '-L <start>,' spans from <start> to end of file. '-L ,<end>' spans from start of file to <end>.
<start> and <end> can take one of these forms:
number
If <start> or <end> is a number, it specifies an absolute line number (lines count from 1).
/regex/
This form will use the first line matching the given POSIX regex. If <start> is a regex, it will search from the end of the previous -L range, if any, otherwise from the start of file. If <start> is '^/regex/', it will search from the start of file. If <end> is a regex, it will search starting at the line given by <start>.
+offset or -offset
This is only valid for <end> and will specify a number of lines before or after the line given by <start>.
If ':<funcname>' is given in place of <start> and <end>, it is a regular expression that denotes the range from the first funcname line that matches <funcname>, up to the next funcname line. ':<funcname>' searches from the end of the previous -L range, if any, otherwise from the start of file. '^:<funcname>' searches from the start of file."),
                    new GitCommandOption("--line-porcelain", @"--line-porcelain",
                        @"Show the porcelain format, but output commit information for each line, not just the first time a commit is referenced. Implies --porcelain."),
                    new GitCommandOption("-M|<num>|", @"-M|<num>|",
                        @"Detect moved or copied lines within a file. When a commit moves or copies a block of lines (e.g. the original file has A and then B, and the commit changes it to B and then A), the traditional blame algorithm notices only half of the movement and typically blames the lines that were moved up (i.e. B) to the parent and assigns blame to the lines that were moved down (i.e. A) to the child commit. With this option, both groups of lines are blamed on the parent by running extra passes of inspection.
<num> is optional but it is the lower bound on the number of alphanumeric characters that Git must detect as moving/copying within a file for it to associate those lines with the parent commit. The default value is 20."),
                    new GitCommandOption("-n", @"-n", @"Show the line number in the original commit (Default: off)."),
                    new GitCommandOption("--no-compaction-heuristic", @"--no-compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-indent-heuristic", @"--no-indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-progress", @"--no-progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal. This flag enables progress reporting even if not attached to a terminal. Can''t use --progress together with --porcelain or --incremental."),
                    new GitCommandOption("-p", @"-p", @"Show in a format designed for machine consumption."),
                    new GitCommandOption("--porcelain", @"--porcelain", @"Show in a format designed for machine consumption."),
                    new GitCommandOption("--progress", @"--progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal. This flag enables progress reporting even if not attached to a terminal. Can''t use --progress together with --porcelain or --incremental."),
                    new GitCommandOption("--reverse ", @"--reverse <rev>..<rev>",
                        @"Walk history forward instead of backward. Instead of showing the revision in which a line appeared, this shows the last revision in which a line has existed. This requires a range of revision like START..END where the path to blame exists in START. git blame --reverse START is taken as git blame --reverse START..HEAD for convenience."),
                    new GitCommandOption("--root", @"--root", @"Do not treat root commits as boundaries. This can also be controlled via the blame.showRoot config option."),
                    new GitCommandOption("-S", @"-S <revs-file>", @"Use revisions from revs-file instead of calling git-rev-list[1]."),
                    new GitCommandOption("-s", @"-s", @"Suppress the author name and timestamp from the output."),
                    new GitCommandOption("--score-debug", @"--score-debug",
                        @"Include debugging information related to the movement of lines between files (see -C) and lines moved within a file (see -M). The first number listed is the score. This is the number of alphanumeric characters detected as having been moved between or within files. This must be above a certain threshold for git blame to consider those lines of code to have been moved."),
                    new GitCommandOption("--show-email", @"--show-email",
                        @"Show the author email instead of author name (Default: off). This can also be controlled via the blame.showEmail config option."),
                    new GitCommandOption("--show-name", @"--show-name",
                        @"Show the filename in the original commit. By default the filename is shown if there is any line that came from a file with a different name, due to rename detection."),
                    new GitCommandOption("--show-number", @"--show-number", @"Show the line number in the original commit (Default: off)."),
                    new GitCommandOption("--show-stats", @"--show-stats", @"Include additional statistics at the end of blame output."),
                    new GitCommandOption("-t", @"-t", @"Show raw timestamp (Default: off)."),
                    new GitCommandOption("-w", @"-w", @"Ignore whitespace when comparing the parent's version and the child's to find where the lines came from.")
                },
                "branch" => new[]
                {
                    new GitCommandOption("-a", @"-a", @"List both remote-tracking branches and local branches."),
                    new GitCommandOption("--abbrev", @"--abbrev=<length>",
                        @"Alter the sha1''s minimum display length in the output listing. The default value is 7 and can be overridden by the core.abbrev config option."),
                    new GitCommandOption("--all", @"--all", @"List both remote-tracking branches and local branches."),
                    new GitCommandOption("--color=", @"--color[=always|never|auto]",
                        @"Color branches to highlight current, local, and remote-tracking branches. The value must be always (the default), never, or auto."),
                    new GitCommandOption("--column=", @"--column[=<options>]",
                        @"Display branch listing in columns. See configuration variable column.branch for option syntax.--column and --no-column without options are equivalent to always and never respectively.
This option is only applicable in non-verbose mode."),
                    new GitCommandOption("--contains", @"--contains [<commit>]", @"Only list branches which contain the specified commit (HEAD if not specified). Implies --list."),
                    new GitCommandOption("--create-reflog", @"--create-reflog",
                        @"Create the branch''s reflog. This activates recording of all changes made to the branch ref, enabling use of date based sha1 expressions such as ""<branchname>@{yesterday}"". Note that in non-bare repositories, reflogs are usually enabled by default by the core.logallrefupdates config option."),
                    new GitCommandOption("-d", @"-d",
                        @"Delete a branch. The branch must be fully merged in its upstream branch, or in HEAD if no upstream was set with --track or --set-upstream."),
                    new GitCommandOption("-D", @"-D", @"Shortcut for --delete --force."),
                    new GitCommandOption("--delete", @"--delete",
                        @"Delete a branch. The branch must be fully merged in its upstream branch, or in HEAD if no upstream was set with --track or --set-upstream."),
                    new GitCommandOption("--edit-description", @"--edit-description",
                        @"Open an editor and edit the text to explain what the branch is for, to be used by various other commands (e.g. format-patch, request-pull, and merge (if enabled)). Multi-line explanations may be used."),
                    new GitCommandOption("-f", @"-f",
                        @"Reset <branchname> to <startpoint> if <branchname> exists already. Without -f git branch refuses to change an existing branch. In combination with -d (or --delete), allow deleting the branch irrespective of its merged status. In combination with -m (or --move), allow renaming the branch even if the new branch name already exists."),
                    new GitCommandOption("--force", @"--force",
                        @"Reset <branchname> to <startpoint> if <branchname> exists already. Without -f git branch refuses to change an existing branch. In combination with -d (or --delete), allow deleting the branch irrespective of its merged status. In combination with -m (or --move), allow renaming the branch even if the new branch name already exists."),
                    new GitCommandOption("-l", @"-l",
                        @"Create the branch''s reflog. This activates recording of all changes made to the branch ref, enabling use of date based sha1 expressions such as ""<branchname>@{yesterday}"". Note that in non-bare repositories, reflogs are usually enabled by default by the core.logallrefupdates config option."),
                    new GitCommandOption("--list", @"--list",
                        @"Activate the list mode. git branch <pattern> would try to create a branch, use git branch --list <pattern> to list matching branches."),
                    new GitCommandOption("-M", @"-M", @"Shortcut for --move --force."), new GitCommandOption("-m", @"-m", @"Move/rename a branch and the corresponding reflog."),
                    new GitCommandOption("--merged", @"--merged [<commit>]",
                        @"Only list branches whose tips are reachable from the specified commit (HEAD if not specified). Implies --list."),
                    new GitCommandOption("--move", @"--move", @"Move/rename a branch and the corresponding reflog."),
                    new GitCommandOption("--no-abbrev", @"--no-abbrev", @"Display the full sha1s in the output listing rather than abbreviating them."),
                    new GitCommandOption("--no-color", @"--no-color", @"Turn off branch colors, even when the configuration file gives the default to color output. Same as --color=never."),
                    new GitCommandOption("--no-column", @"--no-column",
                        @"Display branch listing in columns. See configuration variable column.branch for option syntax.--column and --no-column without options are equivalent to always and never respectively.
This option is only applicable in non-verbose mode."),
                    new GitCommandOption("--no-merged", @"--no-merged [<commit>]",
                        @"Only list branches whose tips are not reachable from the specified commit (HEAD if not specified). Implies --list."),
                    new GitCommandOption("--no-track", @"--no-track", @"Do not set up ""upstream"" configuration, even if the branch.autoSetupMerge configuration variable is true."),
                    new GitCommandOption("--points-at", @"--points-at <object>", @"Only list branches of the given object."),
                    new GitCommandOption("-q", @"-q", @"Be more quiet when creating or deleting a branch, suppressing non-error messages."),
                    new GitCommandOption("--quiet", @"--quiet", @"Be more quiet when creating or deleting a branch, suppressing non-error messages."),
                    new GitCommandOption("-r", @"-r", @"List or delete (if used with -d) the remote-tracking branches."),
                    new GitCommandOption("--remotes", @"--remotes", @"List or delete (if used with -d) the remote-tracking branches."),
                    new GitCommandOption("--set-upstream", @"--set-upstream",
                        @"If specified branch does not exist yet or if --force has been given, acts exactly like --track. Otherwise sets up configuration like --track would when creating the branch, except that where branch points to is not changed."),
                    new GitCommandOption("--set-upstream-to=", @"--set-upstream-to=<upstream>",
                        @"Set up <branchname>''s tracking information so <upstream> is considered <branchname>''s upstream branch. If no <branchname> is specified, then it defaults to the current branch."),
                    new GitCommandOption("--sort=", @"--sort=<key>",
                        @"Sort based on the key given. Prefix - to sort in descending order of the value. You may use the --sort=<key> option multiple times, in which case the last key becomes the primary key. The keys supported are the same as those in git for-each-ref. Sort order defaults to sorting based on the full refname (including refs/... prefix). This lists detached HEAD (if present) first, then local branches and finally remote-tracking branches."),
                    new GitCommandOption("-t", @"-t",
                        @"When creating a new branch, set up branch.<name>.remote and branch.<name>.merge configuration entries to mark the start-point branch as ""upstream"" from the new branch. This configuration will tell git to show the relationship between the two branches in git status and git branch -v. Furthermore, it directs git pull without arguments to pull from the upstream when the new branch is checked out.
This behavior is the default when the start point is a remote-tracking branch. Set the branch.autoSetupMerge configuration variable to false if you want git checkout and git branch to always behave as if --no-track were given. Set it to always if you want this behavior when the start-point is either a local or remote-tracking branch."),
                    new GitCommandOption("--track", @"--track",
                        @"When creating a new branch, set up branch.<name>.remote and branch.<name>.merge configuration entries to mark the start-point branch as ""upstream"" from the new branch. This configuration will tell git to show the relationship between the two branches in git status and git branch -v. Furthermore, it directs git pull without arguments to pull from the upstream when the new branch is checked out.
This behavior is the default when the start point is a remote-tracking branch. Set the branch.autoSetupMerge configuration variable to false if you want git checkout and git branch to always behave as if --no-track were given. Set it to always if you want this behavior when the start-point is either a local or remote-tracking branch."),
                    new GitCommandOption("-u", @"-u <upstream>",
                        @"Set up <branchname>''s tracking information so <upstream> is considered <branchname>''s upstream branch. If no <branchname> is specified, then it defaults to the current branch."),
                    new GitCommandOption("--unset-upstream", @"--unset-upstream",
                        @"Remove the upstream information for <branchname>. If no branch is specified it defaults to the current branch."),
                    new GitCommandOption("-v", @"-v",
                        @"When in list mode, show sha1 and commit subject line for each head, along with relationship to upstream branch (if any). If given twice, print the name of the upstream branch, as well (see also git remote show <remote>)."),
                    new GitCommandOption("--verbose", @"--verbose",
                        @"When in list mode, show sha1 and commit subject line for each head, along with relationship to upstream branch (if any). If given twice, print the name of the upstream branch, as well (see also git remote show <remote>)."),
                    new GitCommandOption("-vv", @"-vv",
                        @"When in list mode, show sha1 and commit subject line for each head, along with relationship to upstream branch (if any). If given twice, print the name of the upstream branch, as well (see also git remote show <remote>).")
                },
                "bundle" => System.Array.Empty<GitCommandOption>(),
                "checkout" => new[]
                {
                    new GitCommandOption("--[no-]progress", @"--[no-]progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal, unless --quiet is specified. This flag enables progress reporting even if not attached to a terminal, regardless of --quiet."),
                    new GitCommandOption("-B", @"-B <new_branch>",
                        @"Creates the branch <new_branch> and start it at <start_point>; if it already exists, then reset it to <start_point>. This is equivalent to running ""git branch"" with ""-f""; see git-branch[1] for details."),
                    new GitCommandOption("-b", @"-b <new_branch>", @"Create a new branch named <new_branch> and start it at <start_point>; see git-branch[1] for details."),
                    new GitCommandOption("--conflict=", @"--conflict=<style>",
                        @"The same as --merge option above, but changes the way the conflicting hunks are presented, overriding the merge.conflictStyle configuration variable. Possible values are ""merge"" (default) and ""diff3"" (in addition to what is shown by ""merge"" style, shows the original contents)."),
                    new GitCommandOption("--detach", @"--detach",
                        @"Rather than checking out a branch to work on it, check out a commit for inspection and discardable experiments. This is the default behavior of ""git checkout <commit>"" when <commit> is not a branch name. See the ""DETACHED HEAD"" section below for details."),
                    new GitCommandOption("-f", @"-f", @"When switching branches, proceed even if the index or the working tree differs from HEAD. This is used to throw away local changes.
When checking out paths from the index, do not fail upon unmerged entries; instead, unmerged entries are ignored."),
                    new GitCommandOption("--force", @"--force",
                        @"When switching branches, proceed even if the index or the working tree differs from HEAD. This is used to throw away local changes.
When checking out paths from the index, do not fail upon unmerged entries; instead, unmerged entries are ignored."),
                    new GitCommandOption("--ignore-other-worktrees", @"--ignore-other-worktrees",
                        @"git checkout refuses when the wanted ref is already checked out by another worktree. This option makes it check the ref out anyway. In other words, the ref can be held by more than one worktree."),
                    new GitCommandOption("--ignore-skip-worktree-bits", @"--ignore-skip-worktree-bits",
                        @"In sparse checkout mode, git checkout -- <paths> would update only entries matched by <paths> and sparse patterns in $GIT_DIR/info/sparse-checkout. This option ignores the sparse patterns and adds back any files in <paths>."),
                    new GitCommandOption("-l", @"-l", @"Create the new branch's reflog; see git-branch[1] for details."), new GitCommandOption("-m", @"-m",
                        @"When switching branches, if you have local modifications to one or more files that are different between the current branch and the branch to which you are switching, the command refuses to switch branches in order to preserve your modifications in context. However, with this option, a three-way merge between the current branch, your working tree contents, and the new branch is done, and you will be on the new branch.
When a merge conflict happens, the index entries for conflicting paths are left unmerged, and you need to resolve the conflicts and mark the resolved paths with git add (or git rm if the merge should result in deletion of the path).
When checking out paths from the index, this option lets you recreate the conflicted merge in the specified paths."),
                    new GitCommandOption("--merge", @"--merge",
                        @"When switching branches, if you have local modifications to one or more files that are different between the current branch and the branch to which you are switching, the command refuses to switch branches in order to preserve your modifications in context. However, with this option, a three-way merge between the current branch, your working tree contents, and the new branch is done, and you will be on the new branch.
When a merge conflict happens, the index entries for conflicting paths are left unmerged, and you need to resolve the conflicts and mark the resolved paths with git add (or git rm if the merge should result in deletion of the path).
When checking out paths from the index, this option lets you recreate the conflicted merge in the specified paths."),
                    new GitCommandOption("--no-track", @"--no-track", @"Do not set up ""upstream"" configuration, even if the branch.autoSetupMerge configuration variable is true."),
                    new GitCommandOption("--orphan", @"--orphan <new_branch>",
                        @"Create a new orphan branch, named <new_branch>, started from <start_point> and switch to it. The first commit made on this new branch will have no parents and it will be the root of a new history totally disconnected from all the other branches and commits.
The index and the working tree are adjusted as if you had previously run ""git checkout <start_point>"". This allows you to start a new history that records a set of paths similar to <start_point> by easily running ""git commit -a"" to make the root commit.
This can be useful when you want to publish the tree from a commit without exposing its full history. You might want to do this to publish an open source branch of a project whose current tree is ""clean"", but whose full history contains proprietary or otherwise encumbered bits of code.
If you want to start a disconnected history that records a set of paths that is totally different from the one of <start_point>, then you should clear the index and the working tree right after creating the orphan branch by running ""git rm -rf ."" from the top level of the working tree. Afterwards you will be ready to prepare your new files, repopulating the working tree, by copying them from elsewhere, extracting a tarball, etc."),
                    new GitCommandOption("--ours", @"--ours", @"When checking out paths from the index, check out stage #2 (ours) or #3 (theirs) for unmerged paths.
Note that during git rebase and git pull --rebase, ours and theirs may appear swapped; --ours gives the version from the branch the changes are rebased onto, while --theirs gives the version from the branch that holds your work that is being rebased.
This is because rebase is used in a workflow that treats the history at the remote as the shared canonical one, and treats the work done on the branch you are rebasing as the third-party work to be integrated, and you are temporarily assuming the role of the keeper of the canonical history during the rebase. As the keeper of the canonical history, you need to view the history from the remote as ours (i.e. ""our shared canonical history""), while what you did on your side branch as theirs (i.e. ""one contributor''s work on top of it"")."),
                    new GitCommandOption("-p", @"-p",
                        @"Interactively select hunks in the difference between the <tree-ish> (or the index, if unspecified) and the working tree. The chosen hunks are then applied in reverse to the working tree (and if a <tree-ish> was specified, the index).
This means that you can use git checkout -p to selectively discard edits from your current working tree. See the 'Interactive Mode' section of git-add[1] to learn how to operate the --patch mode."),
                    new GitCommandOption("--patch", @"--patch",
                        @"Interactively select hunks in the difference between the <tree-ish> (or the index, if unspecified) and the working tree. The chosen hunks are then applied in reverse to the working tree (and if a <tree-ish> was specified, the index).
This means that you can use git checkout -p to selectively discard edits from your current working tree. See the 'Interactive Mode' section of git-add[1] to learn how to operate the --patch mode."),
                    new GitCommandOption("-q", @"-q", @"Quiet, suppress feedback messages."), new GitCommandOption("--quiet", @"--quiet", @"Quiet, suppress feedback messages."),
                    new GitCommandOption("-t", @"-t", @"When creating a new branch, set up ""upstream"" configuration. See ""--track"" in git-branch[1] for details.
If no -b option is given, the name of the new branch will be derived from the remote-tracking branch, by looking at the local part of the refspec configured for the corresponding remote, and then stripping the initial part up to the ""*"". This would tell us to use ""hack"" as the local branch when branching off of ""origin/hack"" (or ""remotes/origin/hack"", or even ""refs/remotes/origin/hack""). If the given name has no slash, or the above guessing results in an empty name, the guessing is aborted. You can explicitly give a name with -b in such a case."),
                    new GitCommandOption("--theirs", @"--theirs", @"When checking out paths from the index, check out stage #2 (ours) or #3 (theirs) for unmerged paths.
Note that during git rebase and git pull --rebase, ours and theirs may appear swapped; --ours gives the version from the branch the changes are rebased onto, while --theirs gives the version from the branch that holds your work that is being rebased.
This is because rebase is used in a workflow that treats the history at the remote as the shared canonical one, and treats the work done on the branch you are rebasing as the third-party work to be integrated, and you are temporarily assuming the role of the keeper of the canonical history during the rebase. As the keeper of the canonical history, you need to view the history from the remote as ours (i.e. ""our shared canonical history""), while what you did on your side branch as theirs (i.e. ""one contributor''s work on top of it"")."),
                    new GitCommandOption("--track", @"--track", @"When creating a new branch, set up ""upstream"" configuration. See ""--track"" in git-branch[1] for details.
If no -b option is given, the name of the new branch will be derived from the remote-tracking branch, by looking at the local part of the refspec configured for the corresponding remote, and then stripping the initial part up to the ""*"". This would tell us to use ""hack"" as the local branch when branching off of ""origin/hack"" (or ""remotes/origin/hack"", or even ""refs/remotes/origin/hack""). If the given name has no slash, or the above guessing results in an empty name, the guessing is aborted. You can explicitly give a name with -b in such a case.")
                },
                "cherry" => System.Array.Empty<GitCommandOption>(),
                "cherry-pick" => new[]
                {
                    new GitCommandOption("--abort", @"--abort", @"Cancel the operation and return to the pre-sequence state."),
                    new GitCommandOption("--allow-empty", @"--allow-empty",
                        @"By default, cherry-picking an empty commit will fail, indicating that an explicit invocation of git commit --allow-empty is required. This option overrides that behavior, allowing empty commits to be preserved automatically in a cherry-pick. Note that when ""--ff"" is in effect, empty commits that meet the ""fast-forward"" requirement will be kept even without this option. Note also, that use of this option only keeps commits that were initially empty (i.e. the commit recorded the same tree as its parent). Commits which are made empty due to a previous commit are dropped. To force the inclusion of those commits use --keep-redundant-commits."),
                    new GitCommandOption("--allow-empty-message", @"--allow-empty-message",
                        @"By default, cherry-picking a commit with an empty message will fail. This option overrides that behavior, allowing commits with empty messages to be cherry picked."),
                    new GitCommandOption("--continue", @"--continue",
                        @"Continue the operation in progress using the information in .git/sequencer. Can be used to continue after resolving conflicts in a failed cherry-pick or revert."),
                    new GitCommandOption("-e", @"-e", @"With this option, git cherry-pick will let you edit the commit message prior to committing."),
                    new GitCommandOption("--edit", @"--edit", @"With this option, git cherry-pick will let you edit the commit message prior to committing."),
                    new GitCommandOption("--ff", @"--ff",
                        @"If the current HEAD is the same as the parent of the cherry-pick''ed commit, then a fast forward to this commit will be performed."),
                    new GitCommandOption("--gpg-sign", @"--gpg-sign[=<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("--keep-redundant-commits", @"--keep-redundant-commits",
                        @"If a commit being cherry picked duplicates a commit already in the current history, it will become empty. By default these redundant commits cause cherry-pick to stop so the user can examine the commit. This option overrides that behavior and creates an empty commit object. Implies --allow-empty."),
                    new GitCommandOption("-m parent-number", @"-m parent-number",
                        @"Usually you cannot cherry-pick a merge because you do not know which side of the merge should be considered the mainline. This option specifies the parent number (starting from 1) of the mainline and allows cherry-pick to replay the change relative to the specified parent."),
                    new GitCommandOption("--mainline parent-number", @"--mainline parent-number",
                        @"Usually you cannot cherry-pick a merge because you do not know which side of the merge should be considered the mainline. This option specifies the parent number (starting from 1) of the mainline and allows cherry-pick to replay the change relative to the specified parent."),
                    new GitCommandOption("-n", @"-n",
                        @"Usually the command automatically creates a sequence of commits. This flag applies the changes necessary to cherry-pick each named commit to your working tree and the index, without making any commit. In addition, when this option is used, your index does not have to match the HEAD commit. The cherry-pick is done against the beginning state of your index.
This is useful when cherry-picking more than one commits'' effect to your index in a row."),
                    new GitCommandOption("--no-commit", @"--no-commit",
                        @"Usually the command automatically creates a sequence of commits. This flag applies the changes necessary to cherry-pick each named commit to your working tree and the index, without making any commit. In addition, when this option is used, your index does not have to match the HEAD commit. The cherry-pick is done against the beginning state of your index.
This is useful when cherry-picking more than one commits'' effect to your index in a row."),
                    new GitCommandOption("--quit", @"--quit",
                        @"Forget about the current operation in progress. Can be used to clear the sequencer state after a failed cherry-pick or revert."),
                    new GitCommandOption("-r", @"-r",
                        @"It used to be that the command defaulted to do -x described above, and -r was to disable it. Now the default is not to do -x so this option is a no-op."),
                    new GitCommandOption("-s", @"-s", @"Add Signed-off-by line at the end of the commit message. See the signoff option in git-commit[1] for more information."),
                    new GitCommandOption("-S[<keyid>]", @"-S[<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("--signoff", @"--signoff",
                        @"Add Signed-off-by line at the end of the commit message. See the signoff option in git-commit[1] for more information."),
                    new GitCommandOption("--strategy", @"--strategy=<strategy>",
                        @"Use the given merge strategy. Should only be used once. See the MERGE STRATEGIES section in git-merge[1] for details."),
                    new GitCommandOption("--strategy-option", @"--strategy-option=<option>",
                        @"Pass the merge strategy-specific option through to the merge strategy. See git-merge[1] for details."),
                    new GitCommandOption("-x", @"-x",
                        @"When recording the commit, append a line that says ""(cherry picked from commit ...)"" to the original commit message in order to indicate which commit this change was cherry-picked from. This is done only for cherry picks without conflicts. Do not use this option if you are cherry-picking from your private branch because the information is useless to the recipient. If on the other hand you are cherry-picking between two publicly visible branches (e.g. backporting a fix to a maintenance branch for an older release from a development branch), adding this information can be useful."),
                    new GitCommandOption("-X<option>", @"-X<option>", @"Pass the merge strategy-specific option through to the merge strategy. See git-merge[1] for details.")
                },
                "citool" => System.Array.Empty<GitCommandOption>(),
                "clean" => new[]
                {
                    new GitCommandOption("-d", @"-d",
                        @"Remove untracked directories in addition to untracked files. If an untracked directory is managed by a different Git repository, it is not removed by default. Use -f option twice if you really want to remove such a directory."),
                    new GitCommandOption("--dry-run", @"--dry-run", @"Don't actually remove anything, just show what would be done."),
                    new GitCommandOption("-e", @"-e <pattern>",
                        @"In addition to those found in .gitignore (per directory) and $GIT_DIR/info/exclude, also consider these patterns to be in the set of the ignore rules in effect."),
                    new GitCommandOption("--exclude", @"--exclude=<pattern>",
                        @"In addition to those found in .gitignore (per directory) and $GIT_DIR/info/exclude, also consider these patterns to be in the set of the ignore rules in effect."),
                    new GitCommandOption("-f", @"-f",
                        @"If the Git configuration variable clean.requireForce is not set to false, git clean will refuse to delete files or directories unless given -f, -n or -i. Git will refuse to delete directories with .git sub directory or file unless a second -f is given."),
                    new GitCommandOption("--force", @"--force",
                        @"If the Git configuration variable clean.requireForce is not set to false, git clean will refuse to delete files or directories unless given -f, -n or -i. Git will refuse to delete directories with .git sub directory or file unless a second -f is given."),
                    new GitCommandOption("-i", @"-i", @"Show what would be done and clean files interactively. See 'Interactive mode' for details."),
                    new GitCommandOption("--interactive", @"--interactive", @"Show what would be done and clean files interactively. See 'Interactive mode' for details."),
                    new GitCommandOption("-n", @"-n", @"Don't actually remove anything, just show what would be done."),
                    new GitCommandOption("-q", @"-q", @"Be quiet, only report errors, but not the files that are successfully removed."),
                    new GitCommandOption("--quiet", @"--quiet", @"Be quiet, only report errors, but not the files that are successfully removed."),
                    new GitCommandOption("-x", @"-x",
                        @"Don''t use the standard ignore rules read from .gitignore (per directory) and $GIT_DIR/info/exclude, but do still use the ignore rules given with -e options. This allows removing all untracked files, including build products. This can be used (possibly in conjunction with git reset) to create a pristine working directory to test a clean build."),
                    new GitCommandOption("-X", @"-X", @"Remove only files ignored by Git. This may be useful to rebuild everything from scratch, but keep manually created files.")
                },
                "clone" => new[]
                {
                    new GitCommandOption("--[no-]shallow-submodules", @"--[no-]shallow-submodules", @"All submodules which are cloned will be shallow with a depth of 1."),
                    new GitCommandOption("--[no-]single-branch", @"--[no-]single-branch",
                        @"Clone only the history leading to the tip of a single branch, either specified by the --branch option or the primary branch remote''s HEAD points at. Further fetches into the resulting repository will only update the remote-tracking branch for the branch this option was used for the initial cloning. If the HEAD at the remote did not point at any branch when --single-branch clone was made, no remote-tracking branch is created."),
                    new GitCommandOption("-b", @"-b <name>",
                        @"Instead of pointing the newly created HEAD to the branch pointed to by the cloned repository''s HEAD, point to <name> branch instead. In a non-bare repository, this is the branch that will be checked out. --branch can also take tags and detaches the HEAD at that commit in the resulting repository."),
                    new GitCommandOption("--bare", @"--bare",
                        @"Make a bare Git repository. That is, instead of creating <directory> and placing the administrative files in <directory>/.git, make the <directory> itself the $GIT_DIR. This obviously implies the -n because there is nowhere to check out the working tree. Also the branch heads at the remote are copied directly to corresponding local branch heads, without mapping them to refs/remotes/origin/. When this option is used, neither remote-tracking branches nor the related configuration variables are created."),
                    new GitCommandOption("--branch", @"--branch <name>",
                        @"Instead of pointing the newly created HEAD to the branch pointed to by the cloned repository''s HEAD, point to <name> branch instead. In a non-bare repository, this is the branch that will be checked out. --branch can also take tags and detaches the HEAD at that commit in the resulting repository."),
                    new GitCommandOption("-c", @"-c <key>=<value>",
                        @"Set a configuration variable in the newly-created repository; this takes effect immediately after the repository is initialized, but before the remote history is fetched or any files checked out. The key is in the same format as expected by git-config[1] (e.g., core.eol=true). If multiple values are given for the same key, each value will be written to the config file. This makes it safe, for example, to add additional fetch refspecs to the origin remote."),
                    new GitCommandOption("--config", @"--config <key>=<value>",
                        @"Set a configuration variable in the newly-created repository; this takes effect immediately after the repository is initialized, but before the remote history is fetched or any files checked out. The key is in the same format as expected by git-config[1] (e.g., core.eol=true). If multiple values are given for the same key, each value will be written to the config file. This makes it safe, for example, to add additional fetch refspecs to the origin remote."),
                    new GitCommandOption("--depth", @"--depth <depth>",
                        @"Create a shallow clone with a history truncated to the specified number of commits. Implies --single-branch unless --no-single-branch is given to fetch the histories near the tips of all branches. If you want to clone submodules shallowly, also pass --shallow-submodules."),
                    new GitCommandOption("--dissociate", @"--dissociate",
                        @"Borrow the objects from reference repositories specified with the --reference options only to reduce network transfer, and stop borrowing from them after a clone is made by making necessary local copies of borrowed objects. This option can also be used when cloning locally from a repository that already borrows objects from another repository...the new repository will borrow objects from the same repository, and this option can be used to stop the borrowing."),
                    new GitCommandOption("-j", @"-j <n>", @"The number of submodules fetched at the same time. Defaults to the submodule.fetchJobs option."),
                    new GitCommandOption("--jobs", @"--jobs <n>", @"The number of submodules fetched at the same time. Defaults to the submodule.fetchJobs option."), new GitCommandOption(
                        "-l", @"-l",
                        @"When the repository to clone from is on a local machine, this flag bypasses the normal ""Git aware"" transport mechanism and clones the repository by making a copy of HEAD and everything under objects and refs directories. The files under .git/objects/ directory are hardlinked to save space when possible.
If the repository is specified as a local path (e.g., /path/to/repo), this is the default, and --local is essentially a no-op. If the repository is specified as a URL, then this flag is ignored (and we never use the local optimizations). Specifying --no-local will override the default when /path/to/repo is given, using the regular Git transport instead."),
                    new GitCommandOption("--local", @"--local",
                        @"When the repository to clone from is on a local machine, this flag bypasses the normal ""Git aware"" transport mechanism and clones the repository by making a copy of HEAD and everything under objects and refs directories. The files under .git/objects/ directory are hardlinked to save space when possible.
If the repository is specified as a local path (e.g., /path/to/repo), this is the default, and --local is essentially a no-op. If the repository is specified as a URL, then this flag is ignored (and we never use the local optimizations). Specifying --no-local will override the default when /path/to/repo is given, using the regular Git transport instead."),
                    new GitCommandOption("--mirror", @"--mirror",
                        @"Set up a mirror of the source repository. This implies --bare. Compared to --bare, --mirror not only maps local branches of the source to local branches of the target, it maps all refs (including remote-tracking branches, notes etc.) and sets up a refspec configuration such that all these refs are overwritten by a git remote update in the target repository."),
                    new GitCommandOption("-n", @"-n", @"No checkout of HEAD is performed after the clone is complete."),
                    new GitCommandOption("--no-checkout", @"--no-checkout", @"No checkout of HEAD is performed after the clone is complete."),
                    new GitCommandOption("--no-hardlinks", @"--no-hardlinks",
                        @"Force the cloning process from a repository on a local filesystem to copy the files under the .git/objects directory instead of using hardlinks. This may be desirable if you are trying to make a back-up of your repository."),
                    new GitCommandOption("-o", @"-o <name>", @"Instead of using the remote name origin to keep track of the upstream repository, use <name>."),
                    new GitCommandOption("--origin", @"--origin <name>", @"Instead of using the remote name origin to keep track of the upstream repository, use <name>."),
                    new GitCommandOption("--progress", @"--progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal, unless -q is specified. This flag forces progress status even if the standard error stream is not directed to a terminal."),
                    new GitCommandOption("-q", @"-q", @"Operate quietly. Progress is not reported to the standard error stream."),
                    new GitCommandOption("--quiet", @"--quiet", @"Operate quietly. Progress is not reported to the standard error stream."),
                    new GitCommandOption("--recurse-submodules", @"--recurse-submodules",
                        @"After the clone is created, initialize all submodules within, using their default settings. This is equivalent to running git submodule update --init --recursive immediately after the clone is finished. This option is ignored if the cloned repository does not have a worktree/checkout (i.e. if any of --no-checkout/-n, --bare, or --mirror is given)"),
                    new GitCommandOption("--recursive", @"--recursive",
                        @"After the clone is created, initialize all submodules within, using their default settings. This is equivalent to running git submodule update --init --recursive immediately after the clone is finished. This option is ignored if the cloned repository does not have a worktree/checkout (i.e. if any of --no-checkout/-n, --bare, or --mirror is given)"),
                    new GitCommandOption("--reference[-if-able]", @"--reference[-if-able] <repository>",
                        @"If the reference repository is on the local machine, automatically setup .git/objects/info/alternates to obtain objects from the reference repository. Using an already existing repository as an alternate will require fewer objects to be copied from the repository being cloned, reducing network and local storage costs. When using the --reference-if-able, a non existing directory is skipped with a warning instead of aborting the clone.
NOTE: see the NOTE for the --shared option, and also the --dissociate option."),
                    new GitCommandOption("-s", @"-s",
                        @"When the repository to clone is on the local machine, instead of using hard links, automatically setup .git/objects/info/alternates to share the objects with the source repository. The resulting repository starts out without any object of its own.
NOTE: this is a possibly dangerous operation; do not use it unless you understand what it does. If you clone your repository using this option and then delete branches (or use any other Git command that makes any existing commit unreferenced) in the source repository, some objects may become unreferenced (or dangling). These objects may be removed by normal Git operations (such as git commit) which automatically call git gc --auto. (See git-gc[1].) If these objects are removed and were referenced by the cloned repository, then the cloned repository will become corrupt.
Note that running git repack without the -l option in a repository cloned with -s will copy objects from the source repository into a pack in the cloned repository, removing the disk space savings of clone -s. It is safe, however, to run git gc, which uses the -l option by default.
If you want to break the dependency of a repository cloned with -s on its source repository, you can simply run git repack -a to copy all objects from the source repository into a pack in the cloned repository."),
                    new GitCommandOption("--separate-git-dir", @"--separate-git-dir=<git dir>",
                        @"Instead of placing the cloned repository where it is supposed to be, place the cloned repository at the specified directory, then make a filesystem-agnostic Git symbolic link to there. The result is Git repository can be separated from working tree."),
                    new GitCommandOption("--shallow-exclude", @"--shallow-exclude=<revision>",
                        @"Create a shallow clone with a history, excluding commits reachable from a specified remote branch or tag. This option can be specified multiple times."),
                    new GitCommandOption("--shallow-since", @"--shallow-since=<date>", @"Create a shallow clone with a history after the specified time."), new GitCommandOption("--shared",
                        @"--shared",
                        @"When the repository to clone is on the local machine, instead of using hard links, automatically setup .git/objects/info/alternates to share the objects with the source repository. The resulting repository starts out without any object of its own.
NOTE: this is a possibly dangerous operation; do not use it unless you understand what it does. If you clone your repository using this option and then delete branches (or use any other Git command that makes any existing commit unreferenced) in the source repository, some objects may become unreferenced (or dangling). These objects may be removed by normal Git operations (such as git commit) which automatically call git gc --auto. (See git-gc[1].) If these objects are removed and were referenced by the cloned repository, then the cloned repository will become corrupt.
Note that running git repack without the -l option in a repository cloned with -s will copy objects from the source repository into a pack in the cloned repository, removing the disk space savings of clone -s. It is safe, however, to run git gc, which uses the -l option by default.
If you want to break the dependency of a repository cloned with -s on its source repository, you can simply run git repack -a to copy all objects from the source repository into a pack in the cloned repository."),
                    new GitCommandOption("--template", @"--template=<template_directory>",
                        @"Specify the directory from which templates will be used; (See the ""TEMPLATE DIRECTORY"" section of git-init[1].)"),
                    new GitCommandOption("-u", @"-u <upload-pack>",
                        @"When given, and the repository to clone from is accessed via ssh, this specifies a non-default path for the command run on the other end."),
                    new GitCommandOption("--upload-pack", @"--upload-pack <upload-pack>",
                        @"When given, and the repository to clone from is accessed via ssh, this specifies a non-default path for the command run on the other end."),
                    new GitCommandOption("-v", @"-v", @"Run verbosely. Does not affect the reporting of progress status to the standard error stream."),
                    new GitCommandOption("--verbose", @"--verbose", @"Run verbosely. Does not affect the reporting of progress status to the standard error stream.")
                },
                "commit" => new[]
                {
                    new GitCommandOption("--", @"--", @"Do not interpret any more arguments as options."),
                    new GitCommandOption("-a", @"-a",
                        @"Tell the command to automatically stage files that have been modified and deleted, but new files you have not told Git about are not affected."),
                    new GitCommandOption("--all", @"--all",
                        @"Tell the command to automatically stage files that have been modified and deleted, but new files you have not told Git about are not affected."),
                    new GitCommandOption("--allow-empty", @"--allow-empty",
                        @"Usually recording a commit that has the exact same tree as its sole parent commit is a mistake, and the command prevents you from making such a commit. This option bypasses the safety, and is primarily for use by foreign SCM interface scripts."),
                    new GitCommandOption("--allow-empty-message", @"--allow-empty-message",
                        @"Like --allow-empty this command is primarily for use by foreign SCM interface scripts. It allows you to create a commit with an empty commit message without using plumbing commands like git-commit-tree[1]."),
                    new GitCommandOption("--amend", @"--amend",
                        @"Replace the tip of the current branch by creating a new commit. The recorded tree is prepared as usual (including the effect of the -i and -o options and explicit pathspec), and the message from the original commit is used as the starting point, instead of an empty message, when no other message is specified from the command line via options such as -m, -F, -c, etc. The new commit has the same parents and author as the current one (the --reset-author option can countermand this).
It is a rough equivalent for:
	$ git reset --soft HEAD^
	$ ... do something else to come up with the right tree ...
	$ git commit -c ORIG_HEAD
but can be used to amend a merge commit.
You should understand the implications of rewriting history if you amend a commit that has already been published. (See the ""RECOVERING FROM UPSTREAM REBASE"" section in git-rebase[1].)"),
                    new GitCommandOption("--author", @"--author=<author>",
                        @"Override the commit author. Specify an explicit author using the standard A U Thor <author@example.com> format. Otherwise <author> is assumed to be a pattern and is used to search for an existing commit by that author (i.e. rev-list --all -i --author=<author>); the commit author is then copied from the first such commit found."),
                    new GitCommandOption("--branch", @"--branch", @"Show the branch and tracking info even in short-format."),
                    new GitCommandOption("-C", @"-C <commit>",
                        @"Take an existing commit object, and reuse the log message and the authorship information (including the timestamp) when creating the commit."),
                    new GitCommandOption("-c", @"-c <commit>", @"Like -C, but with -c the editor is invoked, so that the user can further edit the commit message."), new GitCommandOption(
                        "--cleanup", @"--cleanup=<mode>",
                        @"This option determines how the supplied commit message should be cleaned up before committing. The <mode> can be strip, whitespace, verbatim, scissors or default.
strip
Strip leading and trailing empty lines, trailing whitespace, commentary and collapse consecutive empty lines.
whitespace
Same as strip except #commentary is not removed.
verbatim
Do not change the message at all.
scissors
Same as whitespace, except that everything from (and including) the line ""# ------------------------ >8 ------------------------"" is truncated if the message is to be edited. ""#"" can be customized with core.commentChar.
default
Same as strip if the message is to be edited. Otherwise whitespace.
The default can be changed by the commit.cleanup configuration variable (see git-config[1])."),
                    new GitCommandOption("--date", @"--date=<date>", @"Override the author date used in the commit."),
                    new GitCommandOption("--dry-run", @"--dry-run",
                        @"Do not create a commit, but show a list of paths that are to be committed, paths with local changes that will be left uncommitted and paths that are untracked."),
                    new GitCommandOption("-e", @"-e",
                        @"The message taken from file with -F, command line with -m, and from commit object with -C are usually used as the commit log message unmodified. This option lets you further edit the message taken from these sources."),
                    new GitCommandOption("--edit", @"--edit",
                        @"The message taken from file with -F, command line with -m, and from commit object with -C are usually used as the commit log message unmodified. This option lets you further edit the message taken from these sources."),
                    new GitCommandOption("-F", @"-F <file>", @"Take the commit message from the given file. Use - to read the message from the standard input."),
                    new GitCommandOption("--file", @"--file=<file>", @"Take the commit message from the given file. Use - to read the message from the standard input."),
                    new GitCommandOption("--fixup", @"--fixup=<commit>",
                        @"Construct a commit message for use with rebase --autosquash. The commit message will be the subject line from the specified commit with a prefix of ""fixup! "". See git-rebase[1] for details."),
                    new GitCommandOption("--gpg-sign", @"--gpg-sign[=<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("-i", @"-i",
                        @"Before making a commit out of staged contents so far, stage the contents of paths given on the command line as well. This is usually not what you want unless you are concluding a conflicted merge."),
                    new GitCommandOption("--include", @"--include",
                        @"Before making a commit out of staged contents so far, stage the contents of paths given on the command line as well. This is usually not what you want unless you are concluding a conflicted merge."),
                    new GitCommandOption("--long", @"--long", @"When doing a dry-run, give the output in a the long-format. Implies --dry-run."),
                    new GitCommandOption("-m", @"-m <msg>",
                        @"Use the given <msg> as the commit message. If multiple -m options are given, their values are concatenated as separate paragraphs."),
                    new GitCommandOption("--message", @"--message=<msg>",
                        @"Use the given <msg> as the commit message. If multiple -m options are given, their values are concatenated as separate paragraphs."),
                    new GitCommandOption("-n", @"-n", @"This option bypasses the pre-commit and commit-msg hooks. See also githooks[5]."),
                    new GitCommandOption("--no-edit", @"--no-edit",
                        @"Use the selected commit message without launching an editor. For example, git commit --amend --no-edit amends a commit without changing its commit message."),
                    new GitCommandOption("--no-gpg-sign", @"--no-gpg-sign", @"Countermand commit.gpgSign configuration variable that is set to force each and every commit to be signed."),
                    new GitCommandOption("--no-post-rewrite", @"--no-post-rewrite", @"Bypass the post-rewrite hook."),
                    new GitCommandOption("--no-status", @"--no-status",
                        @"Do not include the output of git-status[1] in the commit message template when using an editor to prepare the default commit message."),
                    new GitCommandOption("--no-verify", @"--no-verify", @"This option bypasses the pre-commit and commit-msg hooks. See also githooks[5]."),
                    new GitCommandOption("--null", @"--null",
                        @"When showing short or porcelain status output, terminate entries in the status output with NUL, instead of LF. If no format is given, implies the --porcelain output format."),
                    new GitCommandOption("-o", @"-o",
                        @"Make a commit by taking the updated working tree contents of the paths specified on the command line, disregarding any contents that have been staged for other paths. This is the default mode of operation of git commit if any paths are given on the command line, in which case this option can be omitted. If this option is specified together with --amend, then no paths need to be specified, which can be used to amend the last commit without committing changes that have already been staged."),
                    new GitCommandOption("--only", @"--only",
                        @"Make a commit by taking the updated working tree contents of the paths specified on the command line, disregarding any contents that have been staged for other paths. This is the default mode of operation of git commit if any paths are given on the command line, in which case this option can be omitted. If this option is specified together with --amend, then no paths need to be specified, which can be used to amend the last commit without committing changes that have already been staged."),
                    new GitCommandOption("-p", @"-p", @"Use the interactive patch selection interface to chose which changes to commit. See git-add[1] for details."),
                    new GitCommandOption("--patch", @"--patch", @"Use the interactive patch selection interface to chose which changes to commit. See git-add[1] for details."),
                    new GitCommandOption("--porcelain", @"--porcelain",
                        @"When doing a dry-run, give the output in a porcelain-ready format. See git-status[1] for details. Implies --dry-run."),
                    new GitCommandOption("-q", @"-q", @"Suppress commit summary message."), new GitCommandOption("--quiet", @"--quiet", @"Suppress commit summary message."),
                    new GitCommandOption("--reedit-message", @"--reedit-message=<commit>",
                        @"Like -C, but with -c the editor is invoked, so that the user can further edit the commit message."),
                    new GitCommandOption("--reset-author", @"--reset-author",
                        @"When used with -C/-c/--amend options, or when committing after a a conflicting cherry-pick, declare that the authorship of the resulting commit now belongs to the committer. This also renews the author timestamp."),
                    new GitCommandOption("--reuse-message", @"--reuse-message=<commit>",
                        @"Take an existing commit object, and reuse the log message and the authorship information (including the timestamp) when creating the commit."),
                    new GitCommandOption("-s", @"-s",
                        @"Add Signed-off-by line by the committer at the end of the commit log message. The meaning of a signoff depends on the project, but it typically certifies that committer has the rights to submit this work under the same license and agrees to a Developer Certificate of Origin (see http://developercertificate.org/ for more information)."),
                    new GitCommandOption("-S[<keyid>]", @"-S[<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("--short", @"--short", @"When doing a dry-run, give the output in the short-format. See git-status[1] for details. Implies --dry-run."),
                    new GitCommandOption("--signoff", @"--signoff",
                        @"Add Signed-off-by line by the committer at the end of the commit log message. The meaning of a signoff depends on the project, but it typically certifies that committer has the rights to submit this work under the same license and agrees to a Developer Certificate of Origin (see http://developercertificate.org/ for more information)."),
                    new GitCommandOption("--squash", @"--squash=<commit>",
                        @"Construct a commit message for use with rebase --autosquash. The commit message subject line is taken from the specified commit with a prefix of ""squash! "". Can be used with additional commit message options (-m/-c/-C/-F). See git-rebase[1] for details."),
                    new GitCommandOption("--status", @"--status",
                        @"Include the output of git-status[1] in the commit message template when using an editor to prepare the commit message. Defaults to on, but can be used to override configuration variable commit.status."),
                    new GitCommandOption("-t", @"-t <file>",
                        @"When editing the commit message, start the editor with the contents in the given file. The commit.template configuration variable is often used to give this option implicitly to the command. This mechanism can be used by projects that want to guide participants with some hints on what to write in the message in what order. If the user exits the editor without editing the message, the commit is aborted. This has no effect when a message is given by other means, e.g. with the -m or -F options."),
                    new GitCommandOption("--template", @"--template=<file>",
                        @"When editing the commit message, start the editor with the contents in the given file. The commit.template configuration variable is often used to give this option implicitly to the command. This mechanism can be used by projects that want to guide participants with some hints on what to write in the message in what order. If the user exits the editor without editing the message, the commit is aborted. This has no effect when a message is given by other means, e.g. with the -m or -F options."),
                    new GitCommandOption("-u[<mode>]", @"-u[<mode>]", @"Show untracked files.
The mode parameter is optional (defaults to all), and is used to specify the handling of untracked files; when -u is not used, the default is normal, i.e. show untracked files and directories.
The possible options are:
no - Show no untracked files
normal - Shows untracked files and directories
all - Also shows individual files in untracked directories.
The default can be changed using the status.showUntrackedFiles configuration variable documented in git-config[1]."),
                    new GitCommandOption("--untracked-files", @"--untracked-files[=<mode>]", @"Show untracked files.
The mode parameter is optional (defaults to all), and is used to specify the handling of untracked files; when -u is not used, the default is normal, i.e. show untracked files and directories.
The possible options are:
no - Show no untracked files
normal - Shows untracked files and directories
all - Also shows individual files in untracked directories.
The default can be changed using the status.showUntrackedFiles configuration variable documented in git-config[1]."),
                    new GitCommandOption("-v", @"-v",
                        @"Show unified diff between the HEAD commit and what would be committed at the bottom of the commit message template to help the user describe the commit by reminding what changes the commit has. Note that this diff output doesn''t have its lines prefixed with #. This diff will not be a part of the commit message. See the commit.verbose configuration variable in git-config[1].
If specified twice, show in addition the unified diff between what would be committed and the worktree files, i.e. the unstaged changes to tracked files."),
                    new GitCommandOption("--verbose", @"--verbose",
                        @"Show unified diff between the HEAD commit and what would be committed at the bottom of the commit message template to help the user describe the commit by reminding what changes the commit has. Note that this diff output doesn''t have its lines prefixed with #. This diff will not be a part of the commit message. See the commit.verbose configuration variable in git-config[1].
If specified twice, show in addition the unified diff between what would be committed and the worktree files, i.e. the unstaged changes to tracked files."),
                    new GitCommandOption("-z", @"-z",
                        @"When showing short or porcelain status output, terminate entries in the status output with NUL, instead of LF. If no format is given, implies the --porcelain output format.")
                },
                "config" => new[]
                {
                    new GitCommandOption("--[no-]includes", @"--[no-]includes",
                        @"Respect include.* directives in config files when looking up values. Defaults to off when a specific file is given (e.g., using --file, --global, etc) and on when searching all config files."),
                    new GitCommandOption("--add", @"--add",
                        @"Adds a new line to the option without altering any existing values. This is the same as providing ^$ as the value_regex in --replace-all."),
                    new GitCommandOption("--blob blob", @"--blob blob",
                        @"Similar to --file but use the given blob instead of a file. E.g. you can use master:.gitmodules to read values from the file .gitmodules in the master branch. See ""SPECIFYING REVISIONS"" section in gitrevisions[7] for a more complete list of ways to spell blob names."),
                    new GitCommandOption("--bool", @"--bool", @"git config will ensure that the output is ""true"" or ""false"""),
                    new GitCommandOption("--bool-or-int", @"--bool-or-int", @"git config will ensure that the output matches the format of either --bool or --int, as described above."),
                    new GitCommandOption("-e", @"-e", @"Opens an editor to modify the specified config file; either --system, --global, or repository (default)."),
                    new GitCommandOption("--edit", @"--edit", @"Opens an editor to modify the specified config file; either --system, --global, or repository (default)."),
                    new GitCommandOption("-f config-file", @"-f config-file", @"Use the given config file instead of the one specified by GIT_CONFIG."),
                    new GitCommandOption("--file config-file", @"--file config-file", @"Use the given config file instead of the one specified by GIT_CONFIG."),
                    new GitCommandOption("--get", @"--get",
                        @"Get the value for a given key (optionally filtered by a regex matching the value). Returns error code 1 if the key was not found and the last value if multiple key values were found."),
                    new GitCommandOption("--get-all", @"--get-all", @"Like get, but returns all values for a multi-valued key."),
                    new GitCommandOption("--get-color name [default]", @"--get-color name [default]",
                        @"Find the color configured for name (e.g. color.diff.new) and output it as the ANSI color escape sequence to the standard output. The optional default parameter is used instead, if there is no color configured for name."),
                    new GitCommandOption("--get-colorbool name [stdout-is-tty]", @"--get-colorbool name [stdout-is-tty]",
                        @"Find the color setting for name (e.g. color.diff) and output ""true"" or ""false"". stdout-is-tty should be either ""true"" or ""false"", and is taken into account when configuration says ""auto"". If stdout-is-tty is missing, then checks the standard output of the command itself, and exits with status 0 if color is to be used, or exits with status 1 otherwise. When the color setting for name is undefined, the command uses color.ui as fallback."),
                    new GitCommandOption("--get-regexp", @"--get-regexp",
                        @"Like --get-all, but interprets the name as a regular expression and writes out the key names. Regular expression matching is currently case-sensitive and done against a canonicalized version of the key in which section and variable names are lowercased, but subsection names are not."),
                    new GitCommandOption("--get-urlmatch name URL", @"--get-urlmatch name URL",
                        @"When given a two-part name section.key, the value for section.<url>.key whose <url> part matches the best to the given URL is returned (if no such key exists, the value for section.key is used as a fallback). When given just the section as name, do so for all the keys in the section and list them. Returns error code 1 if no value is found."),
                    new GitCommandOption("--global", @"--global",
                        @"For writing options: write to global ~/.gitconfig file rather than the repository .git/config, write to $XDG_CONFIG_HOME/git/config file if this file exists and the ~/.gitconfig file doesn''t.
For reading options: read only from global ~/.gitconfig and from $XDG_CONFIG_HOME/git/config rather than from all available files.
See also FILES."),
                    new GitCommandOption("--int", @"--int",
                        @"git config will ensure that the output is a simple decimal number. An optional value suffix of k, m, or g in the config file will cause the value to be multiplied by 1024, 1048576, or 1073741824 prior to output."),
                    new GitCommandOption("-l", @"-l", @"List all variables set in config file, along with their values."),
                    new GitCommandOption("--list", @"--list", @"List all variables set in config file, along with their values."), new GitCommandOption("--local", @"--local",
                        @"For writing options: write to the repository .git/config file. This is the default behavior.
For reading options: read only from the repository .git/config rather than from all available files.
See also FILES."),
                    new GitCommandOption("--name-only", @"--name-only", @"Output only the names of config variables for --list or --get-regexp."),
                    new GitCommandOption("--null", @"--null",
                        @"For all options that output values and/or keys, always end values with the null character (instead of a newline). Use newline instead as a delimiter between key and value. This allows for secure parsing of the output without getting confused e.g. by values that contain line breaks."),
                    new GitCommandOption("--path", @"--path",
                        @"git-config will expand leading ~ to the value of $HOME, and ~user to the home directory for the specified user. This option has no effect when setting the value (but you can use git config bla ~/ from the command line to let your shell do the expansion)."),
                    new GitCommandOption("--remove-section", @"--remove-section", @"Remove the given section from the configuration file."),
                    new GitCommandOption("--rename-section", @"--rename-section", @"Rename the given section to a new name."),
                    new GitCommandOption("--replace-all", @"--replace-all",
                        @"Default behavior is to replace at most one line. This replaces all lines matching the key (and optionally the value_regex)."),
                    new GitCommandOption("--show-origin", @"--show-origin",
                        @"Augment the output of all queried config options with the origin type (file, standard input, blob, command line) and the actual origin (config file path, ref, or blob id if applicable)."),
                    new GitCommandOption("--system", @"--system", @"For writing options: write to system-wide $(prefix)/etc/gitconfig rather than the repository .git/config.
For reading options: read only from system-wide $(prefix)/etc/gitconfig rather than from all available files.
See also FILES."),
                    new GitCommandOption("--unset", @"--unset", @"Remove the line matching the key from config file."),
                    new GitCommandOption("--unset-all", @"--unset-all", @"Remove all lines matching the key from config file."),
                    new GitCommandOption("-z", @"-z",
                        @"For all options that output values and/or keys, always end values with the null character (instead of a newline). Use newline instead as a delimiter between key and value. This allows for secure parsing of the output without getting confused e.g. by values that contain line breaks.")
                },
                "describe" => new[]
                {
                    new GitCommandOption("--abbrev", @"--abbrev=<n>",
                        @"Instead of using the default 7 hexadecimal digits as the abbreviated object name, use <n> digits, or as many digits as needed to form a unique object name. An <n> of 0 will suppress long format, only showing the closest tag."),
                    new GitCommandOption("--all", @"--all",
                        @"Instead of using only the annotated tags, use any ref found in refs/ namespace. This option enables matching any known branch, remote-tracking branch, or lightweight tag."),
                    new GitCommandOption("--always", @"--always", @"Show uniquely abbreviated commit object as fallback."),
                    new GitCommandOption("--candidates", @"--candidates=<n>",
                        @"Instead of considering only the 10 most recent tags as candidates to describe the input commit-ish consider up to <n> candidates. Increasing <n> above 10 will take slightly longer but may produce a more accurate result. An <n> of 0 will cause only exact matches to be output."),
                    new GitCommandOption("--contains", @"--contains",
                        @"Instead of finding the tag that predates the commit, find the tag that comes after the commit, and thus contains it. Automatically implies --tags."),
                    new GitCommandOption("--debug", @"--debug",
                        @"Verbosely display information about the searching strategy being employed to standard error. The tag name will still be printed to standard out."),
                    new GitCommandOption("--dirty", @"--dirty[=<mark>]",
                        @"Describe the working tree. It means describe HEAD and appends <mark> (-dirty by default) if the working tree is dirty."),
                    new GitCommandOption("--exact-match", @"--exact-match",
                        @"Only output exact matches (a tag directly references the supplied commit). This is a synonym for --candidates=0."),
                    new GitCommandOption("--first-parent", @"--first-parent",
                        @"Follow only the first parent commit upon seeing a merge commit. This is useful when you wish to not match tags on branches merged in the history of the target commit."),
                    new GitCommandOption("--long", @"--long",
                        @"Always output the long format (the tag, the number of commits and the abbreviated commit name) even when it matches a tag. This is useful when you want to see parts of the commit object name in ""describe"" output, even when the commit in question happens to be a tagged version. Instead of just emitting the tag name, it will describe such a commit as v1.2-0-gdeadbee (0th commit since tag v1.2 that points at object deadbee....)."),
                    new GitCommandOption("--match", @"--match <pattern>",
                        @"Only consider tags matching the given glob(7) pattern, excluding the ""refs/tags/"" prefix. This can be used to avoid leaking private tags from the repository."),
                    new GitCommandOption("--tags", @"--tags",
                        @"Instead of using only the annotated tags, use any tag found in refs/tags namespace. This option enables matching a lightweight (non-annotated) tag.")
                },
                "diff" => new[]
                {
                    new GitCommandOption("-a", @"-a", @"Treat all files as text."),
                    new GitCommandOption("--abbrev", @"--abbrev[=<n>]",
                        @"Instead of showing the full 40-byte hexadecimal object name in diff-raw format output and diff-tree header lines, show only a partial prefix. This is independent of the --full-index option above, which controls the diff-patch output format. Non default number of digits can be specified with --abbrev=<n>."),
                    new GitCommandOption("-B", @"-B[<n>][/<m>]", @"Break complete rewrite changes into pairs of delete and create. This serves two purposes:
It affects the way a change that amounts to a total rewrite of a file not as a series of deletion and insertion mixed together with a very few lines that happen to match textually as the context, but as a single deletion of everything old followed by a single insertion of everything new, and the number m controls this aspect of the -B option (defaults to 60%). -B/70% specifies that less than 30% of the original should remain in the result for Git to consider it a total rewrite (i.e. otherwise the resulting patch will be a series of deletion and insertion mixed together with context lines).
When used with -M, a totally-rewritten file is also considered as the source of a rename (usually -M only considers a file that disappeared as the source of a rename), and the number n controls this aspect of the -B option (defaults to 50%). -B20% specifies that a change with addition and deletion compared to 20% or more of the file''s size are eligible for being picked up as a possible source of a rename to another file."),
                    new GitCommandOption("-b", @"-b",
                        @"Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent."),
                    new GitCommandOption("--binary", @"--binary", @"In addition to --full-index, output a binary diff that can be applied with git-apply."), new GitCommandOption(
                        "--break-rewrites[=[<n>][/<m>]]", @"--break-rewrites[=[<n>][/<m>]]", @"Break complete rewrite changes into pairs of delete and create. This serves two purposes:
It affects the way a change that amounts to a total rewrite of a file not as a series of deletion and insertion mixed together with a very few lines that happen to match textually as the context, but as a single deletion of everything old followed by a single insertion of everything new, and the number m controls this aspect of the -B option (defaults to 60%). -B/70% specifies that less than 30% of the original should remain in the result for Git to consider it a total rewrite (i.e. otherwise the resulting patch will be a series of deletion and insertion mixed together with context lines).
When used with -M, a totally-rewritten file is also considered as the source of a rename (usually -M only considers a file that disappeared as the source of a rename), and the number n controls this aspect of the -B option (defaults to 50%). -B20% specifies that a change with addition and deletion compared to 20% or more of the file''s size are eligible for being picked up as a possible source of a rename to another file."),
                    new GitCommandOption("-C[<n>]", @"-C[<n>]", @"Detect copies as well as renames. See also --find-copies-harder. If n is specified, it has the same meaning as for -M<n>."),
                    new GitCommandOption("--cached", @"--cached",
                        @"This form is to view the changes you staged for the next commit relative to the named <commit>.
Typically you would want comparison with the latest commit, so if you do not give <commit>, it defaults to HEAD.
If HEAD does not exist (e.g. unborn branches) and <commit> is not given, it shows all staged changes. --staged is a synonym of --cached.
"),
                    new GitCommandOption("--check", @"--check",
                        @"Warn if changes introduce conflict markers or whitespace errors. What are considered whitespace errors is controlled by core.whitespace configuration. By default, trailing whitespaces (including lines that solely consist of whitespaces) and a space character that is immediately followed by a tab character inside the initial indent of the line are considered whitespace errors. Exits with non-zero status if problems are found. Not compatible with --exit-code."),
                    new GitCommandOption("--color", @"--color[=<when>]",
                        @"Show colored diff. --color (i.e. without =<when>) is the same as --color=always. <when> can be one of always, never, or auto. It can be changed by the color.ui and color.diff configuration settings."),
                    new GitCommandOption("--color-words", @"--color-words[=<regex>]", @"Equivalent to --word-diff=color plus (if a regex was specified) --word-diff-regex=<regex>."),
                    new GitCommandOption("--compaction-heuristic", @"--compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("-D", @"-D",
                        @"Omit the preimage for deletes, i.e. print only the header but not the diff between the preimage and /dev/null. The resulting patch is not meant to be applied with patch or git apply; this is solely for people who want to just concentrate on reviewing the text after the change. In addition, the output obviously lack enough information to apply such a patch in reverse, even manually, hence the name of the option.
When used together with -B, omit also the preimage in the deletion part of a delete/create pair."),
                    new GitCommandOption("--diff-algorithm={patience|minimal|histogram|myers}",
                        @"--diff-algorithm={patience|minimal|histogram|myers}", @"Choose a diff algorithm. The variants are as follows:
default, myers
The basic greedy diff algorithm. Currently, this is the default.
minimal
Spend extra time to make sure the smallest possible diff is produced.
patience
Use ""patience diff"" algorithm when generating patches.
histogram
This algorithm extends the patience algorithm to ""support low-occurrence common elements"".
For instance, if you configured diff.algorithm variable to a non-default value and want to use the default one, then you have to use --diff-algorithm=default option."),
                    new GitCommandOption("--diff-filter=", @"--diff-filter=[(A|C|D|M|R|T|U|X|B)...[*]]",
                        @"Select only files that are Added (A), Copied (C), Deleted (D), Modified (M), Renamed (R), have their type (i.e. regular file, symlink, submodule, ...) changed (T), are Unmerged (U), are Unknown (X), or have had their pairing Broken (B). Any combination of the filter characters (including none) can be used. When * (All-or-none) is added to the combination, all paths are selected if there is any file that matches other criteria in the comparison; if there is no file that matches other criteria, nothing is selected.
Also, these upper-case letters can be downcased to exclude. E.g. --diff-filter=ad excludes added and deleted paths."),
                    new GitCommandOption("--dirstat", @"--dirstat[=<param1,param2,...>]",
                        @"Output the distribution of relative amount of changes for each sub-directory. The behavior of --dirstat can be customized by passing it a comma separated list of parameters. The defaults are controlled by the diff.dirstat configuration variable (see git-config[1]). The following parameters are available:
changes
Compute the dirstat numbers by counting the lines that have been removed from the source, or added to the destination. This ignores the amount of pure code movements within a file. In other words, rearranging lines in a file is not counted as much as other changes. This is the default behavior when no parameter is given.
lines
Compute the dirstat numbers by doing the regular line-based diff analysis, and summing the removed/added line counts. (For binary files, count 64-byte chunks instead, since binary files have no natural concept of lines). This is a more expensive --dirstat behavior than the changes behavior, but it does count rearranged lines within a file as much as other changes. The resulting output is consistent with what you get from the other --*stat options.
files
Compute the dirstat numbers by counting the number of files changed. Each changed file counts equally in the dirstat analysis. This is the computationally cheapest --dirstat behavior, since it does not have to look at the file contents at all.
cumulative
Count changes in a child directory for the parent directory as well. Note that when using cumulative, the sum of the percentages reported may exceed 100%. The default (non-cumulative) behavior can be specified with the noncumulative parameter.
<limit>
An integer parameter specifies a cut-off percent (3% by default). Directories contributing less than this percentage of the changes are not shown in the output.
Example: The following will count changed files, while ignoring directories with less than 10% of the total amount of changed files, and accumulating child directory counts in the parent directories: --dirstat=files,10,cumulative."),
                    new GitCommandOption("--dst-prefix", @"--dst-prefix=<prefix>", @"Show the given destination prefix instead of ""b/""."),
                    new GitCommandOption("--exit-code", @"--exit-code",
                        @"Make the program exit with codes similar to diff(1). That is, it exits with 1 if there were differences and 0 means no differences."),
                    new GitCommandOption("--ext-diff", @"--ext-diff",
                        @"Allow an external diff helper to be executed. If you set an external diff driver with gitattributes[5], you need to use this option with git-log[1] and friends."),
                    new GitCommandOption("--find-copies", @"--find-copies[=<n>]",
                        @"Detect copies as well as renames. See also --find-copies-harder. If n is specified, it has the same meaning as for -M<n>."),
                    new GitCommandOption("--find-copies-harder", @"--find-copies-harder",
                        @"For performance reasons, by default, -C option finds copies only if the original file of the copy was modified in the same changeset. This flag makes the command inspect unmodified files as candidates for the source of copy. This is a very expensive operation for large projects, so use it with caution. Giving more than one -C option has the same effect."),
                    new GitCommandOption("--find-renames", @"--find-renames[=<n>]",
                        @"Detect renames. If n is specified, it is a threshold on the similarity index (i.e. amount of addition/deletions compared to the file''s size). For example, -M90% means Git should consider a delete/add pair to be a rename if more than 90% of the file hasn''t changed. Without a % sign, the number is to be read as a fraction, with a decimal point before it. I.e., -M5 becomes 0.5, and is thus the same as -M50%. Similarly, -M05 is the same as -M5%. To limit detection to exact renames, use -M100%. The default similarity index is 50%."),
                    new GitCommandOption("--full-index", @"--full-index",
                        @"Instead of the first handful of characters, show the full pre- and post-image blob object names on the ""index"" line when generating patch format output."),
                    new GitCommandOption("--function-context", @"--function-context", @"Show whole surrounding functions of changes."), new GitCommandOption("-G", @"-G<regex>",
                        @"Look for differences whose patch text contains added/removed lines that match <regex>.
To illustrate the difference between -S<regex> --pickaxe-regex and -G<regex>, consider a commit with the following diff in the same file:
+    return !regexec(regexp, two->ptr, 1, &regmatch, 0);
...
-    hit = !regexec(regexp, mf2.ptr, 1, &regmatch, 0);
While git log -G""regexec\\(regexp"" will show this commit, git log -S""regexec\\(regexp"" --pickaxe-regex will not (because the number of occurrences of that string did not change).
See the pickaxe entry in gitdiffcore[7] for more information."),
                    new GitCommandOption("--histogram", @"--histogram", @"Generate a diff using the ""histogram diff"" algorithm."),
                    new GitCommandOption("--ignore-all-space", @"--ignore-all-space",
                        @"Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other line has none."),
                    new GitCommandOption("--ignore-blank-lines", @"--ignore-blank-lines", @"Ignore changes whose lines are all blank."),
                    new GitCommandOption("--ignore-space-at-eol", @"--ignore-space-at-eol", @"Ignore changes in whitespace at EOL."),
                    new GitCommandOption("--ignore-space-change", @"--ignore-space-change",
                        @"Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent."),
                    new GitCommandOption("--ignore-submodules", @"--ignore-submodules[=<when>]",
                        @"Ignore changes to submodules in the diff generation. <when> can be either ""none"", ""untracked"", ""dirty"" or ""all"", which is the default. Using ""none"" will consider the submodule modified when it either contains untracked or modified files or its HEAD differs from the commit recorded in the superproject and can be used to override any settings of the ignore option in git-config[1] or gitmodules[5]. When ""untracked"" is used submodules are not considered dirty when they only contain untracked content (but they are still scanned for modified content). Using ""dirty"" ignores all changes to the work tree of submodules, only changes to the commits stored in the superproject are shown (this was the behavior until 1.7.0). Using ""all"" hides all changes to submodules."),
                    new GitCommandOption("--indent-heuristic", @"--indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--inter-hunk-context", @"--inter-hunk-context=<lines>",
                        @"Show the context between diff hunks, up to the specified number of lines, thereby fusing hunks that are close to each other."),
                    new GitCommandOption("--irreversible-delete", @"--irreversible-delete",
                        @"Omit the preimage for deletes, i.e. print only the header but not the diff between the preimage and /dev/null. The resulting patch is not meant to be applied with patch or git apply; this is solely for people who want to just concentrate on reviewing the text after the change. In addition, the output obviously lack enough information to apply such a patch in reverse, even manually, hence the name of the option.
When used together with -B, omit also the preimage in the deletion part of a delete/create pair."),
                    new GitCommandOption("--ita-invisible-in-index", @"--ita-invisible-in-index",
                        @"By default entries added by ""git add -N"" appear as an existing empty file in ""git diff"" and a new file in ""git diff --cached"". This option makes the entry appear as a new file in ""git diff"" and non-existent in ""git diff --cached"". This option could be reverted with --ita-visible-in-index. Both options are experimental and could be removed in future."),
                    new GitCommandOption("-l<num>", @"-l<num>",
                        @"The -M and -C options require O(n^2) processing time where n is the number of potential rename/copy targets. This option prevents rename/copy detection from running if the number of rename/copy targets exceeds the specified number."),
                    new GitCommandOption("--line-prefix", @"--line-prefix=<prefix>", @"Prepend an additional prefix to every line of output."),
                    new GitCommandOption("-M[<n>]", @"-M[<n>]",
                        @"Detect renames. If n is specified, it is a threshold on the similarity index (i.e. amount of addition/deletions compared to the file''s size). For example, -M90% means Git should consider a delete/add pair to be a rename if more than 90% of the file hasn''t changed. Without a % sign, the number is to be read as a fraction, with a decimal point before it. I.e., -M5 becomes 0.5, and is thus the same as -M50%. Similarly, -M05 is the same as -M5%. To limit detection to exact renames, use -M100%. The default similarity index is 50%."),
                    new GitCommandOption("--minimal", @"--minimal", @"Spend extra time to make sure the smallest possible diff is produced."),
                    new GitCommandOption("--name-only", @"--name-only", @"Show only names of changed files."),
                    new GitCommandOption("--name-status", @"--name-status",
                        @"Show only names and status of changed files. See the description of the --diff-filter option on what the status letters mean."),
                    new GitCommandOption("--no-color", @"--no-color", @"Turn off colored diff. This can be used to override configuration settings. It is the same as --color=never."),
                    new GitCommandOption("--no-compaction-heuristic", @"--no-compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-ext-diff", @"--no-ext-diff", @"Disallow external diff drivers."),
                    new GitCommandOption("--no-indent-heuristic", @"--no-indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-patch", @"--no-patch",
                        @"Suppress diff output. Useful for commands like git show that show the patch by default, or to cancel the effect of --patch."),
                    new GitCommandOption("--no-prefix", @"--no-prefix", @"Do not show any source or destination prefix."),
                    new GitCommandOption("--no-renames", @"--no-renames", @"Turn off rename detection, even when the configuration file gives the default to do so."),
                    new GitCommandOption("--no-textconv", @"--no-textconv",
                        @"Allow (or disallow) external text conversion filters to be run when comparing binary files. See gitattributes[5] for details. Because textconv filters are typically a one-way conversion, the resulting diff is suitable for human consumption, but cannot be applied. For this reason, textconv filters are enabled by default only for git-diff[1] and git-log[1], but not for git-format-patch[1] or diff plumbing commands."),
                    new GitCommandOption("--numstat", @"--numstat",
                        @"Similar to --stat, but shows number of added and deleted lines in decimal notation and pathname without abbreviation, to make it more machine friendly. For binary files, outputs two - instead of saying 0 0."),
                    new GitCommandOption("-O", @"-O<orderfile>",
                        @"Output the patch in the order specified in the <orderfile>, which has one shell glob pattern per line. This overrides the diff.orderFile configuration variable (see git-config[1]). To cancel diff.orderFile, use -O/dev/null."),
                    new GitCommandOption("-p", @"-p", @"Generate patch (see section on generating patches). This is the default."),
                    new GitCommandOption("--patch", @"--patch", @"Generate patch (see section on generating patches). This is the default."),
                    new GitCommandOption("--patch-with-raw", @"--patch-with-raw", @"Synonym for -p --raw."),
                    new GitCommandOption("--patch-with-stat", @"--patch-with-stat", @"Synonym for -p --stat."),
                    new GitCommandOption("--patience", @"--patience", @"Generate a diff using the ""patience diff"" algorithm."),
                    new GitCommandOption("--pickaxe-all", @"--pickaxe-all",
                        @"When -S or -G finds a change, show all the changes in that changeset, not just the files that contain the change in <string>."),
                    new GitCommandOption("--pickaxe-regex", @"--pickaxe-regex", @"Treat the <string> given to -S as an extended POSIX regular expression to match."),
                    new GitCommandOption("--quiet", @"--quiet", @"Disable all output of the program. Implies --exit-code."),
                    new GitCommandOption("-R", @"-R", @"Swap two inputs; that is, show differences from index or on-disk file to tree contents."),
                    new GitCommandOption("--raw", @"--raw", @"Generate the diff in raw format."),
                    new GitCommandOption("--relative", @"--relative[=<path>]",
                        @"When run from a subdirectory of the project, it can be told to exclude changes outside the directory and show pathnames relative to it with this option. When you are not in a subdirectory (e.g. in a bare repository), you can name which subdirectory to make the output relative to by giving a <path> as an argument."),
                    new GitCommandOption("-S", @"-S<string>",
                        @"Look for differences that change the number of occurrences of the specified string (i.e. addition/deletion) in a file. Intended for the scripter''s use.
It is useful when you''re looking for an exact block of code (like a struct), and want to know the history of that block since it first came into being: use the feature iteratively to feed the interesting block in the preimage back into -S, and keep going until you get the very first version of the block."),
                    new GitCommandOption("-s", @"-s", @"Suppress diff output. Useful for commands like git show that show the patch by default, or to cancel the effect of --patch."),
                    new GitCommandOption("--shortstat", @"--shortstat",
                        @"Output only the last line of the --stat format containing total number of modified files, as well as number of added and deleted lines."),
                    new GitCommandOption("--src-prefix", @"--src-prefix=<prefix>", @"Show the given source prefix instead of ""a/""."), new GitCommandOption(
                        "--stat[[,<name-width>[,<count>]]]", @"--stat[=<width>[,<name-width>[,<count>]]]",
                        @"Generate a diffstat. By default, as much space as necessary will be used for the filename part, and the rest for the graph part. Maximum width defaults to terminal width, or 80 columns if not connected to a terminal, and can be overridden by <width>. The width of the filename part can be limited by giving another width <name-width> after a comma. The width of the graph part can be limited by using --stat-graph-width=<width> (affects all commands generating a stat graph) or by setting diff.statGraphWidth=<width> (does not affect git format-patch). By giving a third parameter <count>, you can limit the output to the first <count> lines, followed by ... if there are more.
These parameters can also be set individually with --stat-width=<width>, --stat-name-width=<name-width> and --stat-count=<count>."),
                    new GitCommandOption("--submodule", @"--submodule[=<format>]",
                        @"Specify how differences in submodules are shown. When specifying --submodule=short the short format is used. This format just shows the names of the commits at the beginning and end of the range. When --submodule or --submodule=log is specified, the log format is used. This format lists the commits in the range like git-submodule[1] summary does. When --submodule=diff is specified, the diff format is used. This format shows an inline diff of the changes in the submodule contents between the commit range. Defaults to diff.submodule or the short format if the config option is unset."),
                    new GitCommandOption("--summary", @"--summary", @"Output a condensed summary of extended header information such as creations, renames and mode changes."),
                    new GitCommandOption("--text", @"--text", @"Treat all files as text."),
                    new GitCommandOption("--textconv", @"--textconv",
                        @"Allow (or disallow) external text conversion filters to be run when comparing binary files. See gitattributes[5] for details. Because textconv filters are typically a one-way conversion, the resulting diff is suitable for human consumption, but cannot be applied. For this reason, textconv filters are enabled by default only for git-diff[1] and git-log[1], but not for git-format-patch[1] or diff plumbing commands."),
                    new GitCommandOption("-u", @"-u", @"Generate patch (see section on generating patches). This is the default."),
                    new GitCommandOption("-U<n>", @"-U<n>", @"Generate diffs with <n> lines of context instead of the usual three. Implies -p."),
                    new GitCommandOption("--unified", @"--unified=<n>", @"Generate diffs with <n> lines of context instead of the usual three. Implies -p."),
                    new GitCommandOption("-W", @"-W", @"Show whole surrounding functions of changes."),
                    new GitCommandOption("-w", @"-w", @"Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other line has none."),
                    new GitCommandOption("--word-diff", @"--word-diff[=<mode>]",
                        @"Show a word diff, using the <mode> to delimit changed words. By default, words are delimited by whitespace; see --word-diff-regex below. The <mode> defaults to plain, and must be one of:
color
Highlight changed words using only colors. Implies --color.
plain
Show words as [-removed-] and {+added+}. Makes no attempts to escape the delimiters if they appear in the input, so the output may be ambiguous.
porcelain
Use a special line-based format intended for script consumption. Added/removed/unchanged runs are printed in the usual unified diff format, starting with a +/-/` ` character at the beginning of the line and extending to the end of the line. Newlines in the input are represented by a tilde ~ on a line of its own.
none
Disable word diff again.
Note that despite the name of the first mode, color is used to highlight the changed parts in all modes if enabled."),
                    new GitCommandOption("--word-diff-regex", @"--word-diff-regex=<regex>",
                        @"Use <regex> to decide what a word is, instead of considering runs of non-whitespace to be a word. Also implies --word-diff unless it was already enabled.
Every non-overlapping match of the <regex> is considered a word. Anything between these matches is considered whitespace and ignored(!) for the purposes of finding differences. You may want to append |[^[:space:]] to your regular expression to make sure that it matches all non-whitespace characters. A match that contains a newline is silently truncated(!) at the newline.
For example, --word-diff-regex=. will treat each character as a word and, correspondingly, show differences character by character.
The regex can also be set via a diff driver or configuration option, see gitattributes[5] or git-config[1]. Giving it explicitly overrides any diff driver or configuration setting. Diff drivers override configuration settings."),
                    new GitCommandOption("--ws-error-highlight", @"--ws-error-highlight=<kind>",
                        @"Highlight whitespace errors on lines specified by <kind> in the color specified by color.diff.whitespace. <kind> is a comma separated list of old, new, context. When this option is not given, only whitespace errors in new lines are highlighted. E.g. --ws-error-highlight=new,old highlights whitespace errors on both deleted and added lines. all can be used as a short-hand for old,new,context. The diff.wsErrorHighlight configuration variable can be used to specify the default behaviour."),
                    new GitCommandOption("-z", @"-z", @"When --raw, --numstat, --name-only or --name-status has been given, do not munge pathnames and use NULs as output field terminators.
Without this option, each pathname output will have TAB, LF, double quotes, and backslash characters replaced with \\t, \\n, \\"", and \\\\, respectively, and the pathname will be enclosed in double quotes if any of those replacements occurred.")
                },
                "difftool" => new[]
                {
                    new GitCommandOption("--[no-]symlinks", @"--[no-]symlinks",
                        @"git difftool''s default behavior is create symlinks to the working tree when run in --dir-diff mode and the right-hand side of the comparison yields the same content as the file in the working tree.
Specifying --no-symlinks instructs git difftool to create copies instead. --no-symlinks is the default on Windows."),
                    new GitCommandOption("--[no-]trust-exit-code",
                        @"--[no-]trust-exit-code",
                        @"git-difftool invokes a diff tool individually on each file. Errors reported by the diff tool are ignored by default. Use --trust-exit-code to make git-difftool exit when an invoked diff tool returns a non-zero exit code.
git-difftool will forward the exit code of the invoked tool when --trust-exit-code is used."),
                    new GitCommandOption("-d", @"-d",
                        @"Copy the modified files to a temporary location and perform a directory diff on them. This mode never prompts before launching the diff tool."),
                    new GitCommandOption("--dir-diff", @"--dir-diff",
                        @"Copy the modified files to a temporary location and perform a directory diff on them. This mode never prompts before launching the diff tool."),
                    new GitCommandOption("--extcmd", @"--extcmd=<command>",
                        @"Specify a custom command for viewing diffs. git-difftool ignores the configured defaults and runs $command $LOCAL $REMOTE when this option is specified. Additionally, $BASE is set in the environment."),
                    new GitCommandOption("-g", @"-g",
                        @"When git-difftool is invoked with the -g or --gui option the default diff tool will be read from the configured diff.guitool variable instead of diff.tool."),
                    new GitCommandOption("--gui", @"--gui",
                        @"When git-difftool is invoked with the -g or --gui option the default diff tool will be read from the configured diff.guitool variable instead of diff.tool."),
                    new GitCommandOption("--no-prompt", @"--no-prompt", @"Do not prompt before launching a diff tool."),
                    new GitCommandOption("--prompt", @"--prompt",
                        @"Prompt before each invocation of the diff tool. This is the default behaviour; the option is provided to override any configuration settings."),
                    new GitCommandOption("-t", @"-t <tool>",
                        @"Use the diff tool specified by <tool>. Valid values include emerge, kompare, meld, and vimdiff. Run git difftool --tool-help for the list of valid <tool> settings.
If a diff tool is not specified, git difftool will use the configuration variable diff.tool. If the configuration variable diff.tool is not set, git difftool will pick a suitable default.
You can explicitly provide a full path to the tool by setting the configuration variable difftool.<tool>.path. For example, you can configure the absolute path to kdiff3 by setting difftool.kdiff3.path. Otherwise, git difftool assumes the tool is available in PATH.
Instead of running one of the known diff tools, git difftool can be customized to run an alternative program by specifying the command line to invoke in a configuration variable difftool.<tool>.cmd.
When git difftool is invoked with this tool (either through the -t or --tool option or the diff.tool configuration variable) the configured command line will be invoked with the following variables available: $LOCAL is set to the name of the temporary file containing the contents of the diff pre-image and $REMOTE is set to the name of the temporary file containing the contents of the diff post-image. $MERGED is the name of the file which is being compared. $BASE is provided for compatibility with custom merge tool commands and has the same value as $MERGED."),
                    new GitCommandOption("--tool", @"--tool=<tool>",
                        @"Use the diff tool specified by <tool>. Valid values include emerge, kompare, meld, and vimdiff. Run git difftool --tool-help for the list of valid <tool> settings.
If a diff tool is not specified, git difftool will use the configuration variable diff.tool. If the configuration variable diff.tool is not set, git difftool will pick a suitable default.
You can explicitly provide a full path to the tool by setting the configuration variable difftool.<tool>.path. For example, you can configure the absolute path to kdiff3 by setting difftool.kdiff3.path. Otherwise, git difftool assumes the tool is available in PATH.
Instead of running one of the known diff tools, git difftool can be customized to run an alternative program by specifying the command line to invoke in a configuration variable difftool.<tool>.cmd.
When git difftool is invoked with this tool (either through the -t or --tool option or the diff.tool configuration variable) the configured command line will be invoked with the following variables available: $LOCAL is set to the name of the temporary file containing the contents of the diff pre-image and $REMOTE is set to the name of the temporary file containing the contents of the diff post-image. $MERGED is the name of the file which is being compared. $BASE is provided for compatibility with custom merge tool commands and has the same value as $MERGED."),
                    new GitCommandOption("--tool-help", @"--tool-help", @"Print a list of diff tools that may be used with --tool."),
                    new GitCommandOption("-x", @"-x <command>",
                        @"Specify a custom command for viewing diffs. git-difftool ignores the configured defaults and runs $command $LOCAL $REMOTE when this option is specified. Additionally, $BASE is set in the environment."),
                    new GitCommandOption("-y", @"-y", @"Do not prompt before launching a diff tool.")
                },
                "fetch" => new[]
                {
                    new GitCommandOption("-4", @"-4", @"Use IPv4 addresses only, ignoring IPv6 addresses."),
                    new GitCommandOption("-6", @"-6", @"Use IPv6 addresses only, ignoring IPv4 addresses."),
                    new GitCommandOption("-a", @"-a",
                        @"Append ref names and object names of fetched refs to the existing contents of .git/FETCH_HEAD. Without this option old data in .git/FETCH_HEAD will be overwritten."),
                    new GitCommandOption("--all", @"--all", @"Fetch all remotes."),
                    new GitCommandOption("--append", @"--append",
                        @"Append ref names and object names of fetched refs to the existing contents of .git/FETCH_HEAD. Without this option old data in .git/FETCH_HEAD will be overwritten."),
                    new GitCommandOption("--deepen", @"--deepen=<depth>",
                        @"Similar to --depth, except it specifies the number of commits from the current shallow boundary instead of from the tip of each remote branch history."),
                    new GitCommandOption("--depth", @"--depth=<depth>",
                        @"Limit fetching to the specified number of commits from the tip of each remote branch history. If fetching to a shallow repository created by git clone with --depth=<depth> option (see git-clone[1]), deepen or shorten the history to the specified number of commits. Tags for the deepened commits are not fetched."),
                    new GitCommandOption("--dry-run", @"--dry-run", @"Show what would be done, without making any changes."),
                    new GitCommandOption("-f", @"-f",
                        @"When git fetch is used with <rbranch>:<lbranch> refspec, it refuses to update the local branch <lbranch> unless the remote branch <rbranch> it fetches is a descendant of <lbranch>. This option overrides that check."),
                    new GitCommandOption("--force", @"--force",
                        @"When git fetch is used with <rbranch>:<lbranch> refspec, it refuses to update the local branch <lbranch> unless the remote branch <rbranch> it fetches is a descendant of <lbranch>. This option overrides that check."),
                    new GitCommandOption("--ipv4", @"--ipv4", @"Use IPv4 addresses only, ignoring IPv6 addresses."),
                    new GitCommandOption("--ipv6", @"--ipv6", @"Use IPv6 addresses only, ignoring IPv4 addresses."),
                    new GitCommandOption("-j", @"-j",
                        @"Number of parallel children to be used for fetching submodules. Each will fetch from different submodules, such that fetching many submodules will be faster. By default submodules will be fetched one at a time."),
                    new GitCommandOption("--jobs", @"--jobs=<n>",
                        @"Number of parallel children to be used for fetching submodules. Each will fetch from different submodules, such that fetching many submodules will be faster. By default submodules will be fetched one at a time."),
                    new GitCommandOption("-k", @"-k", @"Keep downloaded pack."), new GitCommandOption("--keep", @"--keep", @"Keep downloaded pack."),
                    new GitCommandOption("--multiple", @"--multiple", @"Allow several <repository> and <group> arguments to be specified. No <refspec>s may be specified."),
                    new GitCommandOption("-n", @"-n",
                        @"By default, tags that point at objects that are downloaded from the remote repository are fetched and stored locally. This option disables this automatic tag following. The default behavior for a remote may be specified with the remote.<name>.tagOpt setting. See git-config[1]."),
                    new GitCommandOption("--no-recurse-submodules", @"--no-recurse-submodules",
                        @"Disable recursive fetching of submodules (this has the same effect as using the --recurse-submodules=no option)."),
                    new GitCommandOption("--no-tags", @"--no-tags",
                        @"By default, tags that point at objects that are downloaded from the remote repository are fetched and stored locally. This option disables this automatic tag following. The default behavior for a remote may be specified with the remote.<name>.tagOpt setting. See git-config[1]."),
                    new GitCommandOption("-p", @"-p",
                        @"Before fetching, remove any remote-tracking references that no longer exist on the remote. Tags are not subject to pruning if they are fetched only because of the default tag auto-following or due to a --tags option. However, if tags are fetched due to an explicit refspec (either on the command line or in the remote configuration, for example if the remote was cloned with the --mirror option), then they are also subject to pruning."),
                    new GitCommandOption("--progress", @"--progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal, unless -q is specified. This flag forces progress status even if the standard error stream is not directed to a terminal."),
                    new GitCommandOption("--prune", @"--prune",
                        @"Before fetching, remove any remote-tracking references that no longer exist on the remote. Tags are not subject to pruning if they are fetched only because of the default tag auto-following or due to a --tags option. However, if tags are fetched due to an explicit refspec (either on the command line or in the remote configuration, for example if the remote was cloned with the --mirror option), then they are also subject to pruning."),
                    new GitCommandOption("-q", @"-q",
                        @"Pass --quiet to git-fetch-pack and silence any other internally used git commands. Progress is not reported to the standard error stream."),
                    new GitCommandOption("--quiet", @"--quiet",
                        @"Pass --quiet to git-fetch-pack and silence any other internally used git commands. Progress is not reported to the standard error stream."),
                    new GitCommandOption("--recurse-submodules[=yes|on-demand|no]", @"--recurse-submodules[=yes|on-demand|no]",
                        @"This option controls if and under what conditions new commits of populated submodules should be fetched too. It can be used as a boolean option to completely disable recursion when set to no or to unconditionally recurse into all populated submodules when set to yes, which is the default when this option is used without any value. Use on-demand to only recurse into a populated submodule when the superproject retrieves a commit that updates the submodule''s reference to a commit that isn''t already in the local submodule clone."),
                    new GitCommandOption("--recurse-submodules-default=[yes|on-demand]", @"--recurse-submodules-default=[yes|on-demand]",
                        @"This option is used internally to temporarily provide a non-negative default value for the --recurse-submodules option. All other methods of configuring fetch''s submodule recursion (such as settings in gitmodules[5] and git-config[1]) override this option, as does specifying --[no-]recurse-submodules directly."),
                    new GitCommandOption("--refmap", @"--refmap=<refspec>",
                        @"When fetching refs listed on the command line, use the specified refspec (can be given more than once) to map the refs to remote-tracking branches, instead of the values of remote.*.fetch configuration variables for the remote repository. See section on ""Configured Remote-tracking Branches"" for details."),
                    new GitCommandOption("--shallow-exclude", @"--shallow-exclude=<revision>",
                        @"Deepen or shorten the history of a shallow repository to exclude commits reachable from a specified remote branch or tag. This option can be specified multiple times."),
                    new GitCommandOption("--shallow-since", @"--shallow-since=<date>",
                        @"Deepen or shorten the history of a shallow repository to include all reachable commits after <date>."),
                    new GitCommandOption("--submodule-prefix", @"--submodule-prefix=<path>",
                        @"Prepend <path> to paths printed in informative messages such as ""Fetching submodule foo"". This option is used internally when recursing over submodules."),
                    new GitCommandOption("-t", @"-t",
                        @"Fetch all tags from the remote (i.e., fetch remote tags refs/tags/* into local tags with the same name), in addition to whatever else would otherwise be fetched. Using this option alone does not subject tags to pruning, even if --prune is used (though tags may be pruned anyway if they are also the destination of an explicit refspec; see --prune)."),
                    new GitCommandOption("--tags", @"--tags",
                        @"Fetch all tags from the remote (i.e., fetch remote tags refs/tags/* into local tags with the same name), in addition to whatever else would otherwise be fetched. Using this option alone does not subject tags to pruning, even if --prune is used (though tags may be pruned anyway if they are also the destination of an explicit refspec; see --prune)."),
                    new GitCommandOption("-u", @"-u",
                        @"By default git fetch refuses to update the head which corresponds to the current branch. This flag disables the check. This is purely for the internal use for git pull to communicate with git fetch, and unless you are implementing your own Porcelain you are not supposed to use it."),
                    new GitCommandOption("--unshallow", @"--unshallow",
                        @"If the source repository is complete, convert a shallow repository to a complete one, removing all the limitations imposed by shallow repositories.
If the source repository is shallow, fetch as much as possible so that the current repository has the same history as the source repository."),
                    new GitCommandOption("--update-head-ok", @"--update-head-ok",
                        @"By default git fetch refuses to update the head which corresponds to the current branch. This flag disables the check. This is purely for the internal use for git pull to communicate with git fetch, and unless you are implementing your own Porcelain you are not supposed to use it."),
                    new GitCommandOption("--update-shallow", @"--update-shallow",
                        @"By default when fetching from a shallow repository, git fetch refuses refs that require updating .git/shallow. This option updates .git/shallow and accept such refs."),
                    new GitCommandOption("--upload-pack", @"--upload-pack <upload-pack>",
                        @"When given, and the repository to fetch from is handled by git fetch-pack, --exec=<upload-pack> is passed to the command to specify non-default path for the command run on the other end."),
                    new GitCommandOption("-v", @"-v", @"Be verbose."), new GitCommandOption("--verbose", @"--verbose", @"Be verbose.")
                },
                "format-patch" => new[]
                {
                    new GitCommandOption("--[no-]cover-letter", @"--[no-]cover-letter",
                        @"In addition to the patches, generate a cover letter file containing the branch description, shortlog and the overall diffstat. You can fill in a description in the file before sending it out."),
                    new GitCommandOption("--[no]-signature", @"--[no]-signature=<signature>",
                        @"Add a signature to each message produced. Per RFC 3676 the signature is separated from the body by a line with ''-- '' on it. If the signature option is omitted the signature defaults to the Git version number."),
                    new GitCommandOption("-<n>", @"-<n>", @"Prepare patches from the topmost <n> commits."), new GitCommandOption("-a", @"-a", @"Treat all files as text."),
                    new GitCommandOption("--abbrev", @"--abbrev[=<n>]",
                        @"Instead of showing the full 40-byte hexadecimal object name in diff-raw format output and diff-tree header lines, show only a partial prefix. This is independent of the --full-index option above, which controls the diff-patch output format. Non default number of digits can be specified with --abbrev=<n>."),
                    new GitCommandOption("--add-header", @"--add-header=<header>",
                        @"Add an arbitrary header to the email headers. This is in addition to any configured headers, and may be used multiple times. For example, --add-header=""Organization: git-foo"". The negated form --no-add-header discards all (To:, Cc:, and custom) headers added so far from config or command line."),
                    new GitCommandOption("--attach", @"--attach[=<boundary>]",
                        @"Create multipart/mixed attachment, the first part of which is the commit message and the patch itself in the second part, with Content-Disposition: attachment."),
                    new GitCommandOption("-b", @"-b",
                        @"Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent."),
                    new GitCommandOption("-B", @"-B[<n>][/<m>]", @"Break complete rewrite changes into pairs of delete and create. This serves two purposes:
It affects the way a change that amounts to a total rewrite of a file not as a series of deletion and insertion mixed together with a very few lines that happen to match textually as the context, but as a single deletion of everything old followed by a single insertion of everything new, and the number m controls this aspect of the -B option (defaults to 60%). -B/70% specifies that less than 30% of the original should remain in the result for Git to consider it a total rewrite (i.e. otherwise the resulting patch will be a series of deletion and insertion mixed together with context lines).
When used with -M, a totally-rewritten file is also considered as the source of a rename (usually -M only considers a file that disappeared as the source of a rename), and the number n controls this aspect of the -B option (defaults to 50%). -B20% specifies that a change with addition and deletion compared to 20% or more of the file''s size are eligible for being picked up as a possible source of a rename to another file."),
                    new GitCommandOption("--base", @"--base=<commit>",
                        @"Record the base tree information to identify the state the patch series applies to. See the BASE TREE INFORMATION section below for details."),
                    new GitCommandOption("--binary", @"--binary", @"In addition to --full-index, output a binary diff that can be applied with git-apply."), new GitCommandOption(
                        "--break-rewrites", @"--break-rewrites[=[<n>][/<m>]]", @"Break complete rewrite changes into pairs of delete and create. This serves two purposes:
It affects the way a change that amounts to a total rewrite of a file not as a series of deletion and insertion mixed together with a very few lines that happen to match textually as the context, but as a single deletion of everything old followed by a single insertion of everything new, and the number m controls this aspect of the -B option (defaults to 60%). -B/70% specifies that less than 30% of the original should remain in the result for Git to consider it a total rewrite (i.e. otherwise the resulting patch will be a series of deletion and insertion mixed together with context lines).
When used with -M, a totally-rewritten file is also considered as the source of a rename (usually -M only considers a file that disappeared as the source of a rename), and the number n controls this aspect of the -B option (defaults to 50%). -B20% specifies that a change with addition and deletion compared to 20% or more of the file''s size are eligible for being picked up as a possible source of a rename to another file."),
                    new GitCommandOption("-C[<n>]", @"-C[<n>]", @"Detect copies as well as renames. See also --find-copies-harder. If n is specified, it has the same meaning as for -M<n>."),
                    new GitCommandOption("--cc", @"--cc=<email>",
                        @"Add a Cc: header to the email headers. This is in addition to any configured headers, and may be used multiple times. The negated form --no-cc discards all Cc: headers added so far (from config or command line)."),
                    new GitCommandOption("--compaction-heuristic", @"--compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("-D", @"-D",
                        @"Omit the preimage for deletes, i.e. print only the header but not the diff between the preimage and /dev/null. The resulting patch is not meant to be applied with patch or git apply; this is solely for people who want to just concentrate on reviewing the text after the change. In addition, the output obviously lack enough information to apply such a patch in reverse, even manually, hence the name of the option.
When used together with -B, omit also the preimage in the deletion part of a delete/create pair."),
                    new GitCommandOption("--diff-algorithm={patience|minimal|histogram|myers}", @"--diff-algorithm={patience|minimal|histogram|myers}",
                        @"Choose a diff algorithm. The variants are as follows:
default, myers
The basic greedy diff algorithm. Currently, this is the default.
minimal
Spend extra time to make sure the smallest possible diff is produced.
patience
Use ""patience diff"" algorithm when generating patches.
histogram
This algorithm extends the patience algorithm to ""support low-occurrence common elements"".
For instance, if you configured diff.algorithm variable to a non-default value and want to use the default one, then you have to use --diff-algorithm=default option."),
                    new GitCommandOption("--dirstat=", @"--dirstat[=<param1,param2,...>]",
                        @"Output the distribution of relative amount of changes for each sub-directory. The behavior of --dirstat can be customized by passing it a comma separated list of parameters. The defaults are controlled by the diff.dirstat configuration variable (see git-config[1]). The following parameters are available:
changes
Compute the dirstat numbers by counting the lines that have been removed from the source, or added to the destination. This ignores the amount of pure code movements within a file. In other words, rearranging lines in a file is not counted as much as other changes. This is the default behavior when no parameter is given.
lines
Compute the dirstat numbers by doing the regular line-based diff analysis, and summing the removed/added line counts. (For binary files, count 64-byte chunks instead, since binary files have no natural concept of lines). This is a more expensive --dirstat behavior than the changes behavior, but it does count rearranged lines within a file as much as other changes. The resulting output is consistent with what you get from the other --*stat options.
files
Compute the dirstat numbers by counting the number of files changed. Each changed file counts equally in the dirstat analysis. This is the computationally cheapest --dirstat behavior, since it does not have to look at the file contents at all.
cumulative
Count changes in a child directory for the parent directory as well. Note that when using cumulative, the sum of the percentages reported may exceed 100%. The default (non-cumulative) behavior can be specified with the noncumulative parameter.
<limit>
An integer parameter specifies a cut-off percent (3% by default). Directories contributing less than this percentage of the changes are not shown in the output.
Example: The following will count changed files, while ignoring directories with less than 10% of the total amount of changed files, and accumulating child directory counts in the parent directories: --dirstat=files,10,cumulative."),
                    new GitCommandOption("--dst-prefix", @"--dst-prefix=<prefix>", @"Show the given destination prefix instead of ""b/""."),
                    new GitCommandOption("--ext-diff", @"--ext-diff",
                        @"Allow an external diff helper to be executed. If you set an external diff driver with gitattributes[5], you need to use this option with git-log[1] and friends."),
                    new GitCommandOption("--find-copies", @"--find-copies[=<n>]",
                        @"Detect copies as well as renames. See also --find-copies-harder. If n is specified, it has the same meaning as for -M<n>."),
                    new GitCommandOption("--find-copies-harder", @"--find-copies-harder",
                        @"For performance reasons, by default, -C option finds copies only if the original file of the copy was modified in the same changeset. This flag makes the command inspect unmodified files as candidates for the source of copy. This is a very expensive operation for large projects, so use it with caution. Giving more than one -C option has the same effect."),
                    new GitCommandOption("--find-renames", @"--find-renames[=<n>]",
                        @"Detect renames. If n is specified, it is a threshold on the similarity index (i.e. amount of addition/deletions compared to the file''s size). For example, -M90% means Git should consider a delete/add pair to be a rename if more than 90% of the file hasn''t changed. Without a % sign, the number is to be read as a fraction, with a decimal point before it. I.e., -M5 becomes 0.5, and is thus the same as -M50%. Similarly, -M05 is the same as -M5%. To limit detection to exact renames, use -M100%. The default similarity index is 50%."),
                    new GitCommandOption("--from", @"--from=<ident>",
                        @"Use ident in the From: header of each commit email. If the author ident of the commit is not textually identical to the provided ident, place a From: header in the body of the message with the original author. If no ident is given, use the committer ident.
Note that this option is only useful if you are actually sending the emails and want to identify yourself as the sender, but retain the original author (and git am will correctly pick up the in-body header). Note also that git send-email already handles this transformation for you, and this option should not be used if you are feeding the result to git send-email."),
                    new GitCommandOption("--from", @"--from",
                        @"Use ident in the From: header of each commit email. If the author ident of the commit is not textually identical to the provided ident, place a From: header in the body of the message with the original author. If no ident is given, use the committer ident.
Note that this option is only useful if you are actually sending the emails and want to identify yourself as the sender, but retain the original author (and git am will correctly pick up the in-body header). Note also that git send-email already handles this transformation for you, and this option should not be used if you are feeding the result to git send-email."),
                    new GitCommandOption("--full-index", @"--full-index",
                        @"Instead of the first handful of characters, show the full pre- and post-image blob object names on the ""index"" line when generating patch format output."),
                    new GitCommandOption("--function-context", @"--function-context", @"Show whole surrounding functions of changes."),
                    new GitCommandOption("--histogram", @"--histogram", @"Generate a diff using the ""histogram diff"" algorithm."),
                    new GitCommandOption("--ignore-all-space", @"--ignore-all-space",
                        @"Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other line has none."),
                    new GitCommandOption("--ignore-blank-lines", @"--ignore-blank-lines", @"Ignore changes whose lines are all blank."),
                    new GitCommandOption("--ignore-if-in-upstream", @"--ignore-if-in-upstream",
                        @"Do not include a patch that matches a commit in <until>..<since>. This will examine all patches reachable from <since> but not from <until> and compare them with the patches being generated, and any patch that matches is ignored."),
                    new GitCommandOption("--ignore-space-at-eol", @"--ignore-space-at-eol", @"Ignore changes in whitespace at EOL."),
                    new GitCommandOption("--ignore-space-change", @"--ignore-space-change",
                        @"Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent."),
                    new GitCommandOption("--ignore-submodules", @"--ignore-submodules[=<when>]",
                        @"Ignore changes to submodules in the diff generation. <when> can be either ""none"", ""untracked"", ""dirty"" or ""all"", which is the default. Using ""none"" will consider the submodule modified when it either contains untracked or modified files or its HEAD differs from the commit recorded in the superproject and can be used to override any settings of the ignore option in git-config[1] or gitmodules[5]. When ""untracked"" is used submodules are not considered dirty when they only contain untracked content (but they are still scanned for modified content). Using ""dirty"" ignores all changes to the work tree of submodules, only changes to the commits stored in the superproject are shown (this was the behavior until 1.7.0). Using ""all"" hides all changes to submodules."),
                    new GitCommandOption("--indent-heuristic", @"--indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--inline", @"--inline[=<boundary>]",
                        @"Create multipart/mixed attachment, the first part of which is the commit message and the patch itself in the second part, with Content-Disposition: inline."),
                    new GitCommandOption("--in-reply-to=Message-Id", @"--in-reply-to=Message-Id",
                        @"Make the first mail (or all the mails with --no-thread) appear as a reply to the given Message-Id, which avoids breaking threads to provide a new patch series."),
                    new GitCommandOption("--inter-hunk-context", @"--inter-hunk-context=<lines>",
                        @"Show the context between diff hunks, up to the specified number of lines, thereby fusing hunks that are close to each other."),
                    new GitCommandOption("--irreversible-delete", @"--irreversible-delete",
                        @"Omit the preimage for deletes, i.e. print only the header but not the diff between the preimage and /dev/null. The resulting patch is not meant to be applied with patch or git apply; this is solely for people who want to just concentrate on reviewing the text after the change. In addition, the output obviously lack enough information to apply such a patch in reverse, even manually, hence the name of the option.
When used together with -B, omit also the preimage in the deletion part of a delete/create pair."),
                    new GitCommandOption("--ita-invisible-in-index", @"--ita-invisible-in-index",
                        @"By default entries added by ""git add -N"" appear as an existing empty file in ""git diff"" and a new file in ""git diff --cached"". This option makes the entry appear as a new file in ""git diff"" and non-existent in ""git diff --cached"". This option could be reverted with --ita-visible-in-index. Both options are experimental and could be removed in future."),
                    new GitCommandOption("-k", @"-k", @"Do not strip/add [PATCH] from the first line of the commit log message."),
                    new GitCommandOption("--keep-subject", @"--keep-subject", @"Do not strip/add [PATCH] from the first line of the commit log message."),
                    new GitCommandOption("-l<num>", @"-l<num>",
                        @"The -M and -C options require O(n^2) processing time where n is the number of potential rename/copy targets. This option prevents rename/copy detection from running if the number of rename/copy targets exceeds the specified number."),
                    new GitCommandOption("--line-prefix", @"--line-prefix=<prefix>", @"Prepend an additional prefix to every line of output."),
                    new GitCommandOption("-M", @"-M[<n>]",
                        @"Detect renames. If n is specified, it is a threshold on the similarity index (i.e. amount of addition/deletions compared to the file''s size). For example, -M90% means Git should consider a delete/add pair to be a rename if more than 90% of the file hasn''t changed. Without a % sign, the number is to be read as a fraction, with a decimal point before it. I.e., -M5 becomes 0.5, and is thus the same as -M50%. Similarly, -M05 is the same as -M5%. To limit detection to exact renames, use -M100%. The default similarity index is 50%."),
                    new GitCommandOption("--minimal", @"--minimal", @"Spend extra time to make sure the smallest possible diff is produced."),
                    new GitCommandOption("-n", @"-n", @"Name output in [PATCH n/m] format, even with a single patch."), new GitCommandOption("-N", @"-N", @"Name output in [PATCH] format."),
                    new GitCommandOption("--no-attach", @"--no-attach", @"Disable the creation of an attachment, overriding the configuration setting."),
                    new GitCommandOption("--no-binary", @"--no-binary",
                        @"Do not output contents of changes in binary files, instead display a notice that those files changed. Patches generated using this option cannot be applied properly, but they are still useful for code review."),
                    new GitCommandOption("--no-compaction-heuristic", @"--no-compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-ext-diff", @"--no-ext-diff", @"Disallow external diff drivers."),
                    new GitCommandOption("--no-indent-heuristic", @"--no-indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-numbered", @"--no-numbered", @"Name output in [PATCH] format."),
                    new GitCommandOption("--no-prefix", @"--no-prefix", @"Do not show any source or destination prefix."),
                    new GitCommandOption("--no-renames", @"--no-renames", @"Turn off rename detection, even when the configuration file gives the default to do so."),
                    new GitCommandOption("--no-stat", @"--no-stat", @"Generate plain patches without any diffstats."), new GitCommandOption("--notes", @"--notes[=<ref>]",
                        @"Append the notes (see git-notes[1]) for the commit after the three-dash line.
The expected use case of this is to write supporting explanation for the commit that does not belong to the commit log message proper, and include it with the patch submission. While one can simply write these explanations after format-patch has run but before sending, keeping them as Git notes allows them to be maintained between versions of the patch series (but see the discussion of the notes.rewrite configuration options in git-notes[1] to use this workflow)."),
                    new GitCommandOption("--no-textconv", @"--no-textconv",
                        @"Allow (or disallow) external text conversion filters to be run when comparing binary files. See gitattributes[5] for details. Because textconv filters are typically a one-way conversion, the resulting diff is suitable for human consumption, but cannot be applied. For this reason, textconv filters are enabled by default only for git-diff[1] and git-log[1], but not for git-format-patch[1] or diff plumbing commands."),
                    new GitCommandOption("--no-thread", @"--no-thread",
                        @"Controls addition of In-Reply-To and References headers to make the second and subsequent mails appear as replies to the first. Also controls generation of the Message-Id header to reference.
The optional <style> argument can be either shallow or deep. shallow threading makes every mail a reply to the head of the series, where the head is chosen from the cover letter, the --in-reply-to, and the first patch mail, in this order. deep threading makes every mail a reply to the previous one.
The default is --no-thread, unless the format.thread configuration is set. If --thread is specified without a style, it defaults to the style specified by format.thread if any, or else shallow.
Beware that the default for git send-email is to thread emails itself. If you want git format-patch to take care of threading, you will want to ensure that threading is disabled for git send-email."),
                    new GitCommandOption("--numbered", @"--numbered", @"Name output in [PATCH n/m] format, even with a single patch."),
                    new GitCommandOption("--numbered-files", @"--numbered-files",
                        @"Output file names will be a simple number sequence without the default first line of the commit appended."),
                    new GitCommandOption("--numstat", @"--numstat",
                        @"Similar to --stat, but shows number of added and deleted lines in decimal notation and pathname without abbreviation, to make it more machine friendly. For binary files, outputs two - instead of saying 0 0."),
                    new GitCommandOption("-o", @"-o <dir>", @"Use <dir> to store the resulting files, instead of the current working directory."),
                    new GitCommandOption("-O<orderfile>", @"-O<orderfile>",
                        @"Output the patch in the order specified in the <orderfile>, which has one shell glob pattern per line. This overrides the diff.orderFile configuration variable (see git-config[1]). To cancel diff.orderFile, use -O/dev/null."),
                    new GitCommandOption("--output-directory", @"--output-directory <dir>", @"Use <dir> to store the resulting files, instead of the current working directory."),
                    new GitCommandOption("-p", @"-p", @"Generate plain patches without any diffstats."),
                    new GitCommandOption("--patience", @"--patience", @"Generate a diff using the ""patience diff"" algorithm."),
                    new GitCommandOption("-q", @"-q", @"Do not print the names of the generated files to standard output."),
                    new GitCommandOption("--quiet", @"--quiet", @"Do not print the names of the generated files to standard output."),
                    new GitCommandOption("--reroll-count", @"--reroll-count=<n>",
                        @"Mark the series as the <n>-th iteration of the topic. The output filenames have v<n> prepended to them, and the subject prefix (""PATCH"" by default, but configurable via the --subject-prefix option) has ` v<n>` appended to it. E.g. --reroll-count=4 may produce v4-0001-add-makefile.patch file that has ""Subject: [PATCH v4 1/20] Add makefile"" in it."),
                    new GitCommandOption("--rfc", @"--rfc",
                        @"Alias for --subject-prefix=""RFC PATCH"". RFC means ""Request For Comments""; use this when sending an experimental patch for discussion rather than application."),
                    new GitCommandOption("--root", @"--root",
                        @"Treat the revision argument as a <revision range>, even if it is just a single commit (that would normally be treated as a <since>). Note that root commits included in the specified range are always formatted as creation patches, independently of this flag."),
                    new GitCommandOption("-s", @"-s",
                        @"Add Signed-off-by: line to the commit message, using the committer identity of yourself. See the signoff option in git-commit[1] for more information."),
                    new GitCommandOption("--shortstat", @"--shortstat",
                        @"Output only the last line of the --stat format containing total number of modified files, as well as number of added and deleted lines."),
                    new GitCommandOption("--signature-file", @"--signature-file=<file>", @"Works just like --signature except the signature is read from a file."),
                    new GitCommandOption("--signoff", @"--signoff",
                        @"Add Signed-off-by: line to the commit message, using the committer identity of yourself. See the signoff option in git-commit[1] for more information."),
                    new GitCommandOption("--src-prefix", @"--src-prefix=<prefix>", @"Show the given source prefix instead of ""a/""."),
                    new GitCommandOption("--start-number", @"--start-number <n>", @"Start numbering the patches at <n> instead of 1."), new GitCommandOption("--stat=",
                        @"--stat[=<width>[,<name-width>[,<count>]]]",
                        @"Generate a diffstat. By default, as much space as necessary will be used for the filename part, and the rest for the graph part. Maximum width defaults to terminal width, or 80 columns if not connected to a terminal, and can be overridden by <width>. The width of the filename part can be limited by giving another width <name-width> after a comma. The width of the graph part can be limited by using --stat-graph-width=<width> (affects all commands generating a stat graph) or by setting diff.statGraphWidth=<width> (does not affect git format-patch). By giving a third parameter <count>, you can limit the output to the first <count> lines, followed by ... if there are more.
These parameters can also be set individually with --stat-width=<width>, --stat-name-width=<name-width> and --stat-count=<count>."),
                    new GitCommandOption("--stdout", @"--stdout", @"Print all commits to the standard output in mbox format, instead of creating a file for each one."),
                    new GitCommandOption("--subject-prefix", @"--subject-prefix=<Subject-Prefix>",
                        @"Instead of the standard [PATCH] prefix in the subject line, instead use [<Subject-Prefix>]. This allows for useful naming of a patch series, and can be combined with the --numbered option."),
                    new GitCommandOption("--suffix=.<sfx>", @"--suffix=.<sfx>",
                        @"Instead of using .patch as the suffix for generated filenames, use specified suffix. A common alternative is --suffix=.txt. Leaving this empty will remove the .patch suffix.
Note that the leading character does not have to be a dot; for example, you can use --suffix=-patch to get 0001-description-of-my-change-patch."),
                    new GitCommandOption("--summary", @"--summary", @"Output a condensed summary of extended header information such as creations, renames and mode changes."),
                    new GitCommandOption("--text", @"--text", @"Treat all files as text."),
                    new GitCommandOption("--textconv", @"--textconv",
                        @"Allow (or disallow) external text conversion filters to be run when comparing binary files. See gitattributes[5] for details. Because textconv filters are typically a one-way conversion, the resulting diff is suitable for human consumption, but cannot be applied. For this reason, textconv filters are enabled by default only for git-diff[1] and git-log[1], but not for git-format-patch[1] or diff plumbing commands."),
                    new GitCommandOption("--thread", @"--thread[=<style>]",
                        @"Controls addition of In-Reply-To and References headers to make the second and subsequent mails appear as replies to the first. Also controls generation of the Message-Id header to reference.
The optional <style> argument can be either shallow or deep. shallow threading makes every mail a reply to the head of the series, where the head is chosen from the cover letter, the --in-reply-to, and the first patch mail, in this order. deep threading makes every mail a reply to the previous one.
The default is --no-thread, unless the format.thread configuration is set. If --thread is specified without a style, it defaults to the style specified by format.thread if any, or else shallow.
Beware that the default for git send-email is to thread emails itself. If you want git format-patch to take care of threading, you will want to ensure that threading is disabled for git send-email."),
                    new GitCommandOption("--to", @"--to=<email>",
                        @"Add a To: header to the email headers. This is in addition to any configured headers, and may be used multiple times. The negated form --no-to discards all To: headers added so far (from config or command line)."),
                    new GitCommandOption("-U<n>", @"-U<n>", @"Generate diffs with <n> lines of context instead of the usual three."),
                    new GitCommandOption("--unified", @"--unified=<n>", @"Generate diffs with <n> lines of context instead of the usual three."),
                    new GitCommandOption("-v", @"-v <n>",
                        @"Mark the series as the <n>-th iteration of the topic. The output filenames have v<n> prepended to them, and the subject prefix (""PATCH"" by default, but configurable via the --subject-prefix option) has ` v<n>` appended to it. E.g. --reroll-count=4 may produce v4-0001-add-makefile.patch file that has ""Subject: [PATCH v4 1/20] Add makefile"" in it."),
                    new GitCommandOption("-W", @"-W", @"Show whole surrounding functions of changes."),
                    new GitCommandOption("-w", @"-w", @"Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other line has none."),
                    new GitCommandOption("--zero-commit", @"--zero-commit", @"Output an all-zero hash in each patch's From header instead of the hash of the commit.")
                },
                "gc" => new[]
                {
                    new GitCommandOption("--aggressive", @"--aggressive",
                        @"Usually git gc runs very quickly while providing good disk space utilization and performance. This option will cause git gc to more aggressively optimize the repository at the expense of taking much more time. The effects of this optimization are persistent, so this option only needs to be used occasionally; every few hundred changesets or so."),
                    new GitCommandOption("--auto", @"--auto",
                        @"With this option, git gc checks whether any housekeeping is required; if not, it exits without performing any work. Some git commands run git gc --auto after performing operations that could create many loose objects.
Housekeeping is required if there are too many loose objects or too many packs in the repository. If the number of loose objects exceeds the value of the gc.auto configuration variable, then all loose objects are combined into a single pack using git repack -d -l. Setting the value of gc.auto to 0 disables automatic packing of loose objects.
If the number of packs exceeds the value of gc.autoPackLimit, then existing packs (except those marked with a .keep file) are consolidated into a single pack by using the -A option of git repack. Setting gc.autoPackLimit to 0 disables automatic consolidation of packs."),
                    new GitCommandOption("--force", @"--force", @"Force git gc to run even if there may be another git gc instance running on this repository."),
                    new GitCommandOption("--no-prune", @"--no-prune", @"Do not prune any loose objects."),
                    new GitCommandOption("--prune", @"--prune=<date>",
                        @"Prune loose objects older than date (default is 2 weeks ago, overridable by the config variable gc.pruneExpire). --prune=all prunes loose objects regardless of their age (do not use --prune=all unless you know exactly what you are doing. Unless the repository is quiescent, you will lose newly created objects that haven''t been anchored with the refs and end up corrupting your repository). --prune is on by default."),
                    new GitCommandOption("--quiet", @"--quiet", @"Suppress all progress reports.")
                },
                "grep" => new[]
                {
                    new GitCommandOption("--", @"--", @"Signals the end of options; the rest of the parameters are <pathspec> limiters."),
                    new GitCommandOption("-<num>", @"-<num>", @"Show <num> leading and trailing lines, and place a line containing -- between contiguous groups of matches."),
                    new GitCommandOption("-a", @"-a", @"Process binary files as if they were text."),
                    new GitCommandOption("-A", @"-A <num>", @"Show <num> trailing lines, and place a line containing -- between contiguous groups of matches."),
                    new GitCommandOption("--after-context", @"--after-context <num>", @"Show <num> trailing lines, and place a line containing -- between contiguous groups of matches."),
                    new GitCommandOption("--all-match", @"--all-match",
                        @"When giving multiple pattern expressions combined with --or, this flag is specified to limit the match to files that have lines to match all of them."),
                    new GitCommandOption("--and", @"--and",
                        @"Specify how multiple patterns are combined using Boolean expressions. --or is the default operator. --and has higher precedence than --or. -e has to be used for all patterns."),
                    new GitCommandOption("-B", @"-B <num>", @"Show <num> leading lines, and place a line containing -- between contiguous groups of matches."),
                    new GitCommandOption("--basic-regexp", @"--basic-regexp", @"Use POSIX extended/basic regexp for patterns. Default is to use basic regexp."),
                    new GitCommandOption("--before-context", @"--before-context <num>",
                        @"Show <num> leading lines, and place a line containing -- between contiguous groups of matches."),
                    new GitCommandOption("--break", @"--break", @"Print an empty line between matches from different files."),
                    new GitCommandOption("-C", @"-C <num>", @"Show <num> leading and trailing lines, and place a line containing -- between contiguous groups of matches."),
                    new GitCommandOption("-c", @"-c", @"Instead of showing every matched line, show the number of lines that match."),
                    new GitCommandOption("--cached", @"--cached", @"Instead of searching tracked files in the working tree, search blobs registered in the index file."),
                    new GitCommandOption("--color", @"--color[=<when>]", @"Show colored matches. The value must be always (the default), never, or auto."),
                    new GitCommandOption("--context", @"--context <num>", @"Show <num> leading and trailing lines, and place a line containing -- between contiguous groups of matches."),
                    new GitCommandOption("--count", @"--count", @"Instead of showing every matched line, show the number of lines that match."),
                    new GitCommandOption("-e", @"-e",
                        @"The next parameter is the pattern. This option has to be used for patterns starting with - and should be used in scripts passing user input to grep. Multiple patterns are combined by or."),
                    new GitCommandOption("-E", @"-E", @"Use POSIX extended/basic regexp for patterns. Default is to use basic regexp."),
                    new GitCommandOption("--exclude-standard", @"--exclude-standard",
                        @"Do not pay attention to ignored files specified via the .gitignore mechanism. Only useful when searching files in the current directory with --no-index."),
                    new GitCommandOption("--extended-regexp", @"--extended-regexp", @"Use POSIX extended/basic regexp for patterns. Default is to use basic regexp."),
                    new GitCommandOption("-F", @"-F", @"Use fixed strings for patterns (don't interpret pattern as a regex)."),
                    new GitCommandOption("-f", @"-f <file>", @"Read patterns from <file>, one per line."),
                    new GitCommandOption("--files-with-matches", @"--files-with-matches",
                        @"Instead of showing every matched line, show only the names of files that contain (or do not contain) matches. For better compatibility with git diff, --name-only is a synonym for --files-with-matches."),
                    new GitCommandOption("--files-without-match", @"--files-without-match",
                        @"Instead of showing every matched line, show only the names of files that contain (or do not contain) matches. For better compatibility with git diff, --name-only is a synonym for --files-with-matches."),
                    new GitCommandOption("--fixed-strings", @"--fixed-strings", @"Use fixed strings for patterns (don't interpret pattern as a regex)."),
                    new GitCommandOption("--full-name", @"--full-name",
                        @"When run from a subdirectory, the command usually outputs paths relative to the current directory. This option forces paths to be output relative to the project top directory."),
                    new GitCommandOption("--function-context", @"--function-context",
                        @"Show the surrounding text from the previous line containing a function name up to the one before the next function name, effectively showing the whole function in which the match was found."),
                    new GitCommandOption("-G", @"-G", @"Use POSIX extended/basic regexp for patterns. Default is to use basic regexp."),
                    new GitCommandOption("-H", @"-H",
                        @"By default, the command shows the filename for each match. -h option is used to suppress this output. -H is there for completeness and does not do anything except it overrides -h given earlier on the command line."),
                    new GitCommandOption("-h", @"-h",
                        @"By default, the command shows the filename for each match. -h option is used to suppress this output. -H is there for completeness and does not do anything except it overrides -h given earlier on the command line."),
                    new GitCommandOption("--heading", @"--heading", @"Show the filename above the matches in that file instead of at the start of each shown line."),
                    new GitCommandOption("-i", @"-i", @"Ignore case differences between the patterns and the files."),
                    new GitCommandOption("-I", @"-I", @"Don't match the pattern in binary files."),
                    new GitCommandOption("--ignore-case", @"--ignore-case", @"Ignore case differences between the patterns and the files."),
                    new GitCommandOption("--invert-match", @"--invert-match", @"Select non-matching lines."),
                    new GitCommandOption("-l", @"-l",
                        @"Instead of showing every matched line, show only the names of files that contain (or do not contain) matches. For better compatibility with git diff, --name-only is a synonym for --files-with-matches."),
                    new GitCommandOption("-L", @"-L",
                        @"Instead of showing every matched line, show only the names of files that contain (or do not contain) matches. For better compatibility with git diff, --name-only is a synonym for --files-with-matches."),
                    new GitCommandOption("--line-number", @"--line-number", @"Prefix the line number to matching lines."),
                    new GitCommandOption("--max-depth", @"--max-depth <depth>",
                        @"For each <pathspec> given on command line, descend at most <depth> levels of directories. A negative value means no limit. This option is ignored if <pathspec> contains active wildcards. In other words if ""a*"" matches a directory named ""a*"", ""*"" is matched literally so --max-depth is still effective."),
                    new GitCommandOption("-n", @"-n", @"Prefix the line number to matching lines."),
                    new GitCommandOption("--name-only", @"--name-only",
                        @"Instead of showing every matched line, show only the names of files that contain (or do not contain) matches. For better compatibility with git diff, --name-only is a synonym for --files-with-matches."),
                    new GitCommandOption("--no-color", @"--no-color",
                        @"Turn off match highlighting, even when the configuration file gives the default to color output. Same as --color=never."),
                    new GitCommandOption("--no-exclude-standard", @"--no-exclude-standard",
                        @"Also search in ignored files by not honoring the .gitignore mechanism. Only useful with --untracked."),
                    new GitCommandOption("--no-index", @"--no-index", @"Search files in the current directory that is not managed by Git."),
                    new GitCommandOption("--not", @"--not",
                        @"Specify how multiple patterns are combined using Boolean expressions. --or is the default operator. --and has higher precedence than --or. -e has to be used for all patterns."),
                    new GitCommandOption("--no-textconv", @"--no-textconv", @"Do not honor textconv filter settings. This is the default."),
                    new GitCommandOption("--null", @"--null", @"Output \\0 instead of the character that normally follows a file name."),
                    new GitCommandOption("-O[<pager>]", @"-O[<pager>]",
                        @"Open the matching files in the pager (not the output of grep). If the pager happens to be ""less"" or ""vi"", and the user specified only one pattern, the first file is positioned at the first match automatically. The pager argument is optional; if specified, it must be stuck to the option without a space. If pager is unspecified, the default pager will be used (see core.pager in git-config[1])."),
                    new GitCommandOption("--open-files-in-pager", @"--open-files-in-pager[=<pager>]",
                        @"Open the matching files in the pager (not the output of grep). If the pager happens to be ""less"" or ""vi"", and the user specified only one pattern, the first file is positioned at the first match automatically. The pager argument is optional; if specified, it must be stuck to the option without a space. If pager is unspecified, the default pager will be used (see core.pager in git-config[1])."),
                    new GitCommandOption("--or", @"--or",
                        @"Specify how multiple patterns are combined using Boolean expressions. --or is the default operator. --and has higher precedence than --or. -e has to be used for all patterns."),
                    new GitCommandOption("-p", @"-p",
                        @"Show the preceding line that contains the function name of the match, unless the matching line is a function name itself. The name is determined in the same way as git diff works out patch hunk headers (see Defining a custom hunk-header in gitattributes[5])."),
                    new GitCommandOption("-P", @"-P", @"Use Perl-compatible regexp for patterns. Requires libpcre to be compiled in."),
                    new GitCommandOption("--perl-regexp", @"--perl-regexp", @"Use Perl-compatible regexp for patterns. Requires libpcre to be compiled in."),
                    new GitCommandOption("-q", @"-q", @"Do not output matched lines; instead, exit with status 0 when there is a match and with non-zero status when there isn''t."),
                    new GitCommandOption("--quiet", @"--quiet",
                        @"Do not output matched lines; instead, exit with status 0 when there is a match and with non-zero status when there isn''t."),
                    new GitCommandOption("--show-function", @"--show-function",
                        @"Show the preceding line that contains the function name of the match, unless the matching line is a function name itself. The name is determined in the same way as git diff works out patch hunk headers (see Defining a custom hunk-header in gitattributes[5])."),
                    new GitCommandOption("--text", @"--text", @"Process binary files as if they were text."),
                    new GitCommandOption("--textconv", @"--textconv", @"Honor textconv filter settings."),
                    new GitCommandOption("--threads", @"--threads <num>", @"Number of grep worker threads to use. See grep.threads in CONFIGURATION for more information."),
                    new GitCommandOption("--untracked", @"--untracked", @"In addition to searching in the tracked files in the working tree, search also in untracked files."),
                    new GitCommandOption("-v", @"-v", @"Select non-matching lines."),
                    new GitCommandOption("-w", @"-w",
                        @"Match the pattern only at word boundary (either begin at the beginning of a line, or preceded by a non-word character; end at the end of a line or followed by a non-word character)."),
                    new GitCommandOption("-W", @"-W",
                        @"Show the surrounding text from the previous line containing a function name up to the one before the next function name, effectively showing the whole function in which the match was found."),
                    new GitCommandOption("--word-regexp", @"--word-regexp",
                        @"Match the pattern only at word boundary (either begin at the beginning of a line, or preceded by a non-word character; end at the end of a line or followed by a non-word character)."),
                    new GitCommandOption("-z", @"-z", @"Output \\0 instead of the character that normally follows a file name.")
                },
                "gui" => System.Array.Empty<GitCommandOption>(),
                "help" => new[]
                {
                    new GitCommandOption("-a", @"-a", @"Prints all the available commands on the standard output. This option overrides any given command or guide name."),
                    new GitCommandOption("--all", @"--all", @"Prints all the available commands on the standard output. This option overrides any given command or guide name."),
                    new GitCommandOption("-g", @"-g", @"Prints a list of useful guides on the standard output. This option overrides any given command or guide name."),
                    new GitCommandOption("--guides", @"--guides", @"Prints a list of useful guides on the standard output. This option overrides any given command or guide name."),
                    new GitCommandOption("-i", @"-i", @"Display manual page for the command in the info format. The info program will be used for that purpose."),
                    new GitCommandOption("--info", @"--info", @"Display manual page for the command in the info format. The info program will be used for that purpose."),
                    new GitCommandOption("-m", @"-m",
                        @"Display manual page for the command in the man format. This option may be used to override a value set in the help.format configuration variable.
By default the man program will be used to display the manual page, but the man.viewer configuration variable may be used to choose other display programs (see below)."),
                    new GitCommandOption("--man", @"--man",
                        @"Display manual page for the command in the man format. This option may be used to override a value set in the help.format configuration variable.
By default the man program will be used to display the manual page, but the man.viewer configuration variable may be used to choose other display programs (see below)."),
                    new GitCommandOption("-w", @"-w", @"Display manual page for the command in the web (HTML) format. A web browser will be used for that purpose.
The web browser can be specified using the configuration variable help.browser, or web.browser if the former is not set. If none of these config variables is set, the git web{litdd}browse helper script (called by git help) will pick a suitable default. See git-web{litdd}browse[1] for more information about this."),
                    new GitCommandOption("--web", @"--web", @"Display manual page for the command in the web (HTML) format. A web browser will be used for that purpose.
The web browser can be specified using the configuration variable help.browser, or web.browser if the former is not set. If none of these config variables is set, the git web{litdd}browse helper script (called by git help) will pick a suitable default. See git-web{litdd}browse[1] for more information about this.")
                },
                "init" => new[]
                {
                    new GitCommandOption("--bare", @"--bare", @"Create a bare repository. If GIT_DIR environment is not set, it is set to the current working directory."),
                    new GitCommandOption("-q", @"-q", @"Only print error and warning messages; all other output will be suppressed."),
                    new GitCommandOption("--quiet", @"--quiet", @"Only print error and warning messages; all other output will be suppressed."), new GitCommandOption("--separate-git-dir",
                        @"--separate-git-dir=<git dir>",
                        @"Instead of initializing the repository as a directory to either $GIT_DIR or ./.git/, create a text file there containing the path to the actual repository. This file acts as filesystem-agnostic Git symbolic link to the repository.
If this is reinitialization, the repository will be moved to the specified path."),
                    new GitCommandOption("--shared[=(false|true|umask|group|all|world|everybody|0xxx)]", @"--shared[=(false|true|umask|group|all|world|everybody|0xxx)]",
                        @"Specify that the Git repository is to be shared amongst several users. This allows users belonging to the same group to push into that repository. When specified, the config variable ""core.sharedRepository"" is set so that files and directories under $GIT_DIR are created with the requested permissions. When not specified, Git will use permissions reported by umask(2).
The option can have the following values, defaulting to group if no value is given:"),
                    new GitCommandOption("--template", @"--template=<template_directory>",
                        @"Specify the directory from which templates will be used. (See the ""TEMPLATE DIRECTORY"" section below.)")
                },
                "instaweb" => new[]
                {
                    new GitCommandOption("-b", @"-b",
                        @"The web browser that should be used to view the gitweb page. This will be passed to the git web{litdd}browse helper script along with the URL of the gitweb instance. See git-web{litdd}browse[1] for more information about this. If the script fails, the URL will be printed to stdout."),
                    new GitCommandOption("--browser", @"--browser",
                        @"The web browser that should be used to view the gitweb page. This will be passed to the git web{litdd}browse helper script along with the URL of the gitweb instance. See git-web{litdd}browse[1] for more information about this. If the script fails, the URL will be printed to stdout."),
                    new GitCommandOption("-d", @"-d",
                        @"The HTTP daemon command-line that will be executed. Command-line options may be specified here, and the configuration file will be added at the end of the command-line. Currently apache2, lighttpd, mongoose, plackup and webrick are supported. (Default: lighttpd)"),
                    new GitCommandOption("--httpd", @"--httpd",
                        @"The HTTP daemon command-line that will be executed. Command-line options may be specified here, and the configuration file will be added at the end of the command-line. Currently apache2, lighttpd, mongoose, plackup and webrick are supported. (Default: lighttpd)"),
                    new GitCommandOption("-l", @"-l", @"Only bind the web server to the local IP (127.0.0.1)."),
                    new GitCommandOption("--local", @"--local", @"Only bind the web server to the local IP (127.0.0.1)."),
                    new GitCommandOption("-m", @"-m", @"The module path (only needed if httpd is Apache). (Default: /usr/lib/apache2/modules)"),
                    new GitCommandOption("--module-path", @"--module-path", @"The module path (only needed if httpd is Apache). (Default: /usr/lib/apache2/modules)"),
                    new GitCommandOption("-p", @"-p", @"The port number to bind the httpd to. (Default: 1234)"),
                    new GitCommandOption("--port", @"--port", @"The port number to bind the httpd to. (Default: 1234)"),
                    new GitCommandOption("--restart", @"--restart", @"Restart the httpd instance and exit. Regenerate configuration files as necessary for spawning a new instance."),
                    new GitCommandOption("--start", @"--start", @"Start the httpd instance and exit. Regenerate configuration files as necessary for spawning a new instance."),
                    new GitCommandOption("--stop", @"--stop",
                        @"Stop the httpd instance and exit. This does not generate any of the configuration files for spawning a new instance, nor does it close the browser.")
                },
                "log" => new[]
                {
                    new GitCommandOption("[\\--]...", @"[\\--] <path>...",
                        @"Show only commits that are enough to explain how the files that match the specified paths came to be. See History Simplification below for details and other simplification modes.
Paths may need to be prefixed with ''`-- '''' to separate them from options or the revision range, when confusion arises."),
                    new GitCommandOption("--[no-]standard-notes", @"--[no-]standard-notes", @"These options are deprecated. Use the above --notes/--no-notes options instead."),
                    new GitCommandOption("-<number>", @"-<number>", @"Limit the number of commits to output."), new GitCommandOption("-a", @"-a", @"Treat all files as text."),
                    new GitCommandOption("--abbrev", @"--abbrev[=<n>]",
                        @"Instead of showing the full 40-byte hexadecimal object name in diff-raw format output and diff-tree header lines, show only a partial prefix. This is independent of the --full-index option above, which controls the diff-patch output format. Non default number of digits can be specified with --abbrev=<n>."),
                    new GitCommandOption("--abbrev-commit", @"--abbrev-commit",
                        @"Instead of showing the full 40-byte hexadecimal commit object name, show only a partial prefix. Non default number of digits can be specified with ""--abbrev=<n>"" (which also modifies diff output, if it is displayed).
This should make ""--pretty=oneline"" a whole lot more readable for people using 80-column terminals."),
                    new GitCommandOption("--after", @"--after=<date>", @"Show commits more recent than a specific date."),
                    new GitCommandOption("--all", @"--all", @"Pretend as if all the refs in refs/ are listed on the command line as <commit>."),
                    new GitCommandOption("--all-match", @"--all-match", @"Limit the commits output to ones that match all given --grep, instead of ones that match at least one."),
                    new GitCommandOption("--ancestry-path", @"--ancestry-path",
                        @"When given a range of commits to display (e.g. commit1..commit2 or commit2 ^commit1), only display commits that exist directly on the ancestry chain between the commit1 and commit2, i.e. commits that are both descendants of commit1, and ancestors of commit2."),
                    new GitCommandOption("--ancestry-path", @"--ancestry-path",
                        @"Limit the displayed commits to those directly on the ancestry chain between the 'from' and 'to' commits in the given commit range. I.e. only display commits that are ancestor of the 'to' commit and descendants of the 'from' commit.
As an example use case, consider the following commit history:
	    D---E-------F
	   /     \\       \\
	  B---C---G---H---I---J
	 /                     \\
	A-------K---------------L--M
A regular D..M computes the set of commits that are ancestors of M, but excludes the ones that are ancestors of D. This is useful to see what happened to the history leading to M since D, in the sense that 'what does M have that did not exist in D'. The result in this example would be all the commits, except A and B (and D itself, of course).
When we want to find out what commits in M are contaminated with the bug introduced by D and need fixing, however, we might want to view only the subset of D..M that are actually descendants of D, i.e. excluding C and K. This is exactly what the --ancestry-path option does. Applied to the D..M range, it results in:
		E-------F
		 \\       \\
		  G---H---I---J
			       \\
				L--M"),
                    new GitCommandOption("--author", @"--author=<pattern>",
                        @"Limit the commits output to ones with author/committer header lines that match the specified pattern (regular expression). With more than one --author=<pattern>, commits whose author matches any of the given patterns are chosen (similarly for multiple --committer=<pattern>)."),
                    new GitCommandOption("--author-date-order", @"--author-date-order",
                        @"Show no parents before all of its children are shown, but otherwise show commits in the author timestamp order."),
                    new GitCommandOption("-b", @"-b",
                        @"Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent."),
                    new GitCommandOption("-B[<n>][/<m>]", @"-B[<n>][/<m>]", @"Break complete rewrite changes into pairs of delete and create. This serves two purposes:
It affects the way a change that amounts to a total rewrite of a file not as a series of deletion and insertion mixed together with a very few lines that happen to match textually as the context, but as a single deletion of everything old followed by a single insertion of everything new, and the number m controls this aspect of the -B option (defaults to 60%). -B/70% specifies that less than 30% of the original should remain in the result for Git to consider it a total rewrite (i.e. otherwise the resulting patch will be a series of deletion and insertion mixed together with context lines).
When used with -M, a totally-rewritten file is also considered as the source of a rename (usually -M only considers a file that disappeared as the source of a rename), and the number n controls this aspect of the -B option (defaults to 50%). -B20% specifies that a change with addition and deletion compared to 20% or more of the file''s size are eligible for being picked up as a possible source of a rename to another file."),
                    new GitCommandOption("--basic-regexp", @"--basic-regexp", @"Consider the limiting patterns to be basic regular expressions; this is the default."),
                    new GitCommandOption("--before", @"--before=<date>", @"Show commits older than a specific date."),
                    new GitCommandOption("--binary", @"--binary", @"In addition to --full-index, output a binary diff that can be applied with git-apply."),
                    new GitCommandOption("--bisect", @"--bisect",
                        @"Pretend as if the bad bisection ref refs/bisect/bad was listed and as if it was followed by --not and the good bisection refs refs/bisect/good-* on the command line. Cannot be combined with --first-parent."),
                    new GitCommandOption("--boundary", @"--boundary", @"Output excluded boundary commits. Boundary commits are prefixed with -."),
                    new GitCommandOption("--branches", @"--branches[=<pattern>]",
                        @"Pretend as if all the refs in refs/heads are listed on the command line as <commit>. If <pattern> is given, limit branches to ones matching given shell glob. If pattern lacks ?, *, or [, /* at the end is implied."),
                    new GitCommandOption("--break-rewrites[=[<n>][/<m>]]", @"--break-rewrites[=[<n>][/<m>]]",
                        @"Break complete rewrite changes into pairs of delete and create. This serves two purposes:
It affects the way a change that amounts to a total rewrite of a file not as a series of deletion and insertion mixed together with a very few lines that happen to match textually as the context, but as a single deletion of everything old followed by a single insertion of everything new, and the number m controls this aspect of the -B option (defaults to 60%). -B/70% specifies that less than 30% of the original should remain in the result for Git to consider it a total rewrite (i.e. otherwise the resulting patch will be a series of deletion and insertion mixed together with context lines).
When used with -M, a totally-rewritten file is also considered as the source of a rename (usually -M only considers a file that disappeared as the source of a rename), and the number n controls this aspect of the -B option (defaults to 50%). -B20% specifies that a change with addition and deletion compared to 20% or more of the file''s size are eligible for being picked up as a possible source of a rename to another file."),
                    new GitCommandOption("-c", @"-c",
                        @"With this option, diff output for a merge commit shows the differences from each of the parents to the merge result simultaneously instead of showing pairwise diff between a parent and the result one at a time. Furthermore, it lists only files which were modified from all parents."),
                    new GitCommandOption("-C[<n>]", @"-C[<n>]", @"Detect copies as well as renames. See also --find-copies-harder. If n is specified, it has the same meaning as for -M<n>."),
                    new GitCommandOption("--cc", @"--cc",
                        @"This flag implies the -c option and further compresses the patch output by omitting uninteresting hunks whose contents in the parents have only two variants and the merge result picks one of them without modification."),
                    new GitCommandOption("--check", @"--check",
                        @"Warn if changes introduce conflict markers or whitespace errors. What are considered whitespace errors is controlled by core.whitespace configuration. By default, trailing whitespaces (including lines that solely consist of whitespaces) and a space character that is immediately followed by a tab character inside the initial indent of the line are considered whitespace errors. Exits with non-zero status if problems are found. Not compatible with --exit-code."),
                    new GitCommandOption("--cherry", @"--cherry",
                        @"A synonym for --right-only --cherry-mark --no-merges; useful to limit the output to the commits on our side and mark those that have been applied to the other side of a forked history with git log --cherry upstream...mybranch, similar to git cherry upstream mybranch."),
                    new GitCommandOption("--cherry-mark", @"--cherry-mark",
                        @"Like --cherry-pick (see below) but mark equivalent commits with = rather than omitting them, and inequivalent ones with +."),
                    new GitCommandOption("--cherry-pick",
                        @"--cherry-pick",
                        @"Omit any commit that introduces the same change as another commit on the 'other side' when the set of commits are limited with symmetric difference.
For example, if you have two branches, A and B, a usual way to list all commits on only one side of them is with --left-right (see the example below in the description of the --left-right option). However, it shows the commits that were cherry-picked from the other branch (for example, '3rd on b' may be cherry-picked from branch A). With this option, such pairs of commits are excluded from the output."),
                    new GitCommandOption("--children", @"--children",
                        @"Print also the children of the commit (in the form ""commit child...""). Also enables parent rewriting, see History Simplification below."),
                    new GitCommandOption("--color", @"--color[=<when>]",
                        @"Show colored diff. --color (i.e. without =<when>) is the same as --color=always. <when> can be one of always, never, or auto."),
                    new GitCommandOption("--color-words", @"--color-words[=<regex>]", @"Equivalent to --word-diff=color plus (if a regex was specified) --word-diff-regex=<regex>."),
                    new GitCommandOption("--committer", @"--committer=<pattern>",
                        @"Limit the commits output to ones with author/committer header lines that match the specified pattern (regular expression). With more than one --author=<pattern>, commits whose author matches any of the given patterns are chosen (similarly for multiple --committer=<pattern>)."),
                    new GitCommandOption("--compaction-heuristic", @"--compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("-D", @"-D",
                        @"Omit the preimage for deletes, i.e. print only the header but not the diff between the preimage and /dev/null. The resulting patch is not meant to be applied with patch or git apply; this is solely for people who want to just concentrate on reviewing the text after the change. In addition, the output obviously lack enough information to apply such a patch in reverse, even manually, hence the name of the option.
When used together with -B, omit also the preimage in the deletion part of a delete/create pair."),
                    new GitCommandOption("--date", @"--date=<format>",
                        @"Only takes effect for dates shown in human-readable format, such as when using --pretty. log.date config variable sets a default value for the log command''s --date option. By default, dates are shown in the original time zone (either committer''s or author''s). If -local is appended to the format (e.g., iso-local), the user''s local time zone is used instead.
--date=relative shows dates relative to the current time, e.g. '2 hours ago'. The -local option has no effect for --date=relative.
--date=local is an alias for --date=default-local.
--date=iso (or --date=iso8601) shows timestamps in a ISO 8601-like format. The differences to the strict ISO 8601 format are:
a space instead of the T date/time delimiter
a space between time and time zone
no colon between hours and minutes of the time zone
--date=iso-strict (or --date=iso8601-strict) shows timestamps in strict ISO 8601 format.
+ --date=rfc (or --date=rfc2822) shows timestamps in RFC 2822 format, often found in email messages.
+ --date=short shows only the date, but not the time, in YYYY-MM-DD format.
+ --date=raw shows the date as seconds since the epoch (1970-01-01 00:00:00 UTC), followed by a space, and then the timezone as an offset from UTC (a + or - with four digits; the first two are hours, and the second two are minutes). I.e., as if the timestamp were formatted with strftime(""%s %z"")). Note that the -local option does not affect the seconds-since-epoch value (which is always measured in UTC), but does switch the accompanying timezone value.
+ --date=unix shows the date as a Unix epoch timestamp (seconds since 1970). As with --raw, this is always in UTC and therefore -local has no effect.
+ --date=format:... feeds the format ... to your system strftime. Use --date=format:%c to show the date in your system locale''s preferred format. See the strftime manual for a complete list of format placeholders. When using -local, the correct syntax is --date=format-local:....
+ --date=default is the default format, and is similar to --date=rfc2822, with a few exceptions:
there is no comma after the day-of-week
the time zone is omitted when the local time zone is used"),
                    new GitCommandOption("--date-order", @"--date-order", @"Show no parents before all of its children are shown, but otherwise show commits in the commit timestamp order."),
                    new GitCommandOption("--decorate[=short|full|auto|no]", @"--decorate[=short|full|auto|no]",
                        @"Print out the ref names of any commits that are shown. If short is specified, the ref name prefixes refs/heads/, refs/tags/ and refs/remotes/ will not be printed. If full is specified, the full ref name (including prefix) will be printed. If auto is specified, then if the output is going to a terminal, the ref names are shown as if short were given, otherwise no ref names are shown. The default option is short."),
                    new GitCommandOption("--dense", @"--dense", @"Commits that are walked are included if they are not TREESAME to any parent."),
                    new GitCommandOption("--dense", @"--dense", @"Only the selected commits are shown, plus some to have a meaningful history."), new GitCommandOption(
                        "--diff-algorithm={patience|minimal|histogram|myers}", @"--diff-algorithm={patience|minimal|histogram|myers}", @"Choose a diff algorithm. The variants are as follows:
default, myers
The basic greedy diff algorithm. Currently, this is the default.
minimal
Spend extra time to make sure the smallest possible diff is produced.
patience
Use ""patience diff"" algorithm when generating patches.
histogram
This algorithm extends the patience algorithm to ""support low-occurrence common elements"".
For instance, if you configured diff.algorithm variable to a non-default value and want to use the default one, then you have to use --diff-algorithm=default option."),
                    new GitCommandOption("--diff-filter=[(A|C|D|M|R|T|U|X|B)...[*]]", @"--diff-filter=[(A|C|D|M|R|T|U|X|B)...[*]]",
                        @"Select only files that are Added (A), Copied (C), Deleted (D), Modified (M), Renamed (R), have their type (i.e. regular file, symlink, submodule, ...) changed (T), are Unmerged (U), are Unknown (X), or have had their pairing Broken (B). Any combination of the filter characters (including none) can be used. When * (All-or-none) is added to the combination, all paths are selected if there is any file that matches other criteria in the comparison; if there is no file that matches other criteria, nothing is selected.
Also, these upper-case letters can be downcased to exclude. E.g. --diff-filter=ad excludes added and deleted paths."),
                    new GitCommandOption("--dirstat", @"--dirstat[=<param1,param2,...>",
                        @"Output the distribution of relative amount of changes for each sub-directory. The behavior of --dirstat can be customized by passing it a comma separated list of parameters. The defaults are controlled by the diff.dirstat configuration variable (see git-config[1]). The following parameters are available:
changes
Compute the dirstat numbers by counting the lines that have been removed from the source, or added to the destination. This ignores the amount of pure code movements within a file. In other words, rearranging lines in a file is not counted as much as other changes. This is the default behavior when no parameter is given.
lines
Compute the dirstat numbers by doing the regular line-based diff analysis, and summing the removed/added line counts. (For binary files, count 64-byte chunks instead, since binary files have no natural concept of lines). This is a more expensive --dirstat behavior than the changes behavior, but it does count rearranged lines within a file as much as other changes. The resulting output is consistent with what you get from the other --*stat options.
files
Compute the dirstat numbers by counting the number of files changed. Each changed file counts equally in the dirstat analysis. This is the computationally cheapest --dirstat behavior, since it does not have to look at the file contents at all.
cumulative
Count changes in a child directory for the parent directory as well. Note that when using cumulative, the sum of the percentages reported may exceed 100%. The default (non-cumulative) behavior can be specified with the noncumulative parameter.
<limit>
An integer parameter specifies a cut-off percent (3% by default). Directories contributing less than this percentage of the changes are not shown in the output.
Example: The following will count changed files, while ignoring directories with less than 10% of the total amount of changed files, and accumulating child directory counts in the parent directories: --dirstat=files,10,cumulative."),
                    new GitCommandOption("--do-walk", @"--do-walk", @"Overrides a previous --no-walk."),
                    new GitCommandOption("--dst-prefix", @"--dst-prefix=<prefix>", @"Show the given destination prefix instead of ""b/""."),
                    new GitCommandOption("-E", @"-E", @"Consider the limiting patterns to be extended regular expressions instead of the default basic regular expressions."),
                    new GitCommandOption("--encoding", @"--encoding=<encoding>",
                        @"The commit objects record the encoding used for the log message in their encoding header; this option can be used to tell the command to re-code the commit log message in the encoding preferred by the user. For non plumbing commands this defaults to UTF-8. Note that if an object claims to be encoded in X and we are outputting in X, we will output the object verbatim; this means that invalid sequences in the original commit may be copied to the output."),
                    new GitCommandOption("--exclude", @"--exclude=<glob-pattern>",
                        @"Do not include refs matching <glob-pattern> that the next --all, --branches, --tags, --remotes, or --glob would otherwise consider. Repetitions of this option accumulate exclusion patterns up to the next --all, --branches, --tags, --remotes, or --glob option (other options or arguments do not clear accumulated patterns).
The patterns given should not begin with refs/heads, refs/tags, or refs/remotes when applied to --branches, --tags, or --remotes, respectively, and they must begin with refs/ when applied to --glob or --all. If a trailing /* is intended, it must be given explicitly."),
                    new GitCommandOption("--expand-tabs", @"--expand-tabs",
                        @"Perform a tab expansion (replace each tab with enough spaces to fill to the next display column that is multiple of <n>) in the log message before showing it in the output. --expand-tabs is a short-hand for --expand-tabs=8, and --no-expand-tabs is a short-hand for --expand-tabs=0, which disables tab expansion.
By default, tabs are expanded in pretty formats that indent the log message by 4 spaces (i.e. medium, which is the default, full, and fuller)."),
                    new GitCommandOption("--expand-tabs", @"--expand-tabs=<n>",
                        @"Perform a tab expansion (replace each tab with enough spaces to fill to the next display column that is multiple of <n>) in the log message before showing it in the output. --expand-tabs is a short-hand for --expand-tabs=8, and --no-expand-tabs is a short-hand for --expand-tabs=0, which disables tab expansion.
By default, tabs are expanded in pretty formats that indent the log message by 4 spaces (i.e. medium, which is the default, full, and fuller)."),
                    new GitCommandOption("--ext-diff", @"--ext-diff",
                        @"Allow an external diff helper to be executed. If you set an external diff driver with gitattributes[5], you need to use this option with git-log[1] and friends."),
                    new GitCommandOption("--extended-regexp", @"--extended-regexp",
                        @"Consider the limiting patterns to be extended regular expressions instead of the default basic regular expressions."),
                    new GitCommandOption("-F", @"-F", @"Consider the limiting patterns to be fixed strings (don't interpret pattern as a regular expression)."),
                    new GitCommandOption("--find-copies", @"--find-copies[=<n>]",
                        @"Detect copies as well as renames. See also --find-copies-harder. If n is specified, it has the same meaning as for -M<n>."),
                    new GitCommandOption("--find-copies-harder", @"--find-copies-harder",
                        @"For performance reasons, by default, -C option finds copies only if the original file of the copy was modified in the same changeset. This flag makes the command inspect unmodified files as candidates for the source of copy. This is a very expensive operation for large projects, so use it with caution. Giving more than one -C option has the same effect."),
                    new GitCommandOption("--find-renames", @"--find-renames[=<n>]",
                        @"If generating diffs, detect and report renames for each commit. For following files across renames while traversing history, see --follow. If n is specified, it is a threshold on the similarity index (i.e. amount of addition/deletions compared to the file''s size). For example, -M90% means Git should consider a delete/add pair to be a rename if more than 90% of the file hasn''t changed. Without a % sign, the number is to be read as a fraction, with a decimal point before it. I.e., -M5 becomes 0.5, and is thus the same as -M50%. Similarly, -M05 is the same as -M5%. To limit detection to exact renames, use -M100%. The default similarity index is 50%."),
                    new GitCommandOption("--first-parent", @"--first-parent",
                        @"Follow only the first parent commit upon seeing a merge commit. This option can give a better overview when viewing the evolution of a particular topic branch, because merges into a topic branch tend to be only about adjusting to updated upstream from time to time, and this option allows you to ignore the individual commits brought in to your history by such a merge. Cannot be combined with --bisect."),
                    new GitCommandOption("--fixed-strings", @"--fixed-strings", @"Consider the limiting patterns to be fixed strings (don't interpret pattern as a regular expression)."),
                    new GitCommandOption("--follow", @"--follow", @"Continue listing the history of a file beyond renames (works only for a single file)."), new GitCommandOption("--format",
                        @"--format=<format>",
                        @"Pretty-print the contents of the commit logs in a given format, where <format> can be one of oneline, short, medium, full, fuller, email, raw, format:<string> and tformat:<string>. When <format> is none of the above, and has %placeholder in it, it acts as if --pretty=tformat:<format> were given.
See the ""PRETTY FORMATS"" section for some additional details for each format. When =<format> part is omitted, it defaults to medium.
Note: you can specify the default pretty format in the repository configuration (see git-config[1])."),
                    new GitCommandOption("--full-diff", @"--full-diff",
                        @"Without this flag, git log -p <path>... shows commits that touch the specified paths, and diffs about the same specified paths. With this, the full diff is shown for commits that touch the specified paths; this means that ""<path>..."" limits only commits, and doesn''t limit diff for those commits.
Note that this affects all diff-based output types, e.g. those produced by --stat, etc."),
                    new GitCommandOption("--full-history", @"--full-history", @"Same as the default mode, but does not prune some history."), new GitCommandOption(
                        "--full-history with parent rewriting", @"--full-history with parent rewriting",
                        @"Ordinary commits are only included if they are !TREESAME (though this can be changed, see --sparse below).
Merges are always included. However, their parent list is rewritten: Along each parent, prune away commits that are not included themselves. This results in
	  .-A---M---N---O---P---Q
	 /     /   /   /   /
	I     B   /   D   /
	 \\   /   /   /   /
	  `-------------''
Compare to --full-history without rewriting above. Note that E was pruned away because it is TREESAME, but the parent list of P was rewritten to contain E''s parent I. The same happened for C and N, and X, Y and Q."),
                    new GitCommandOption("--full-history without parent rewriting", @"--full-history without parent rewriting",
                        @"This mode differs from the default in one point: always follow all parents of a merge, even if it is TREESAME to one of them. Even if more than one side of the merge has commits that are included, this does not imply that the merge itself is! In the example, we get
	I  A  B  N  D  O  P  Q
M was excluded because it is TREESAME to both parents. E, C and B were all walked, but only B was !TREESAME, so the others do not appear.
Note that without parent rewriting, it is not really possible to talk about the parent/child relationships between the commits, so we show them disconnected."),
                    new GitCommandOption("--full-index", @"--full-index",
                        @"Instead of the first handful of characters, show the full pre- and post-image blob object names on the ""index"" line when generating patch format output."),
                    new GitCommandOption("--function-context", @"--function-context", @"Show whole surrounding functions of changes."), new GitCommandOption("-g", @"-g",
                        @"Instead of walking the commit ancestry chain, walk reflog entries from the most recent one to older ones. When this option is used you cannot specify commits to exclude (that is, ^commit, commit1..commit2, and commit1...commit2 notations cannot be used).
With --pretty format other than oneline (for obvious reasons), this causes the output to have two extra lines of information taken from the reflog. The reflog designator in the output may be shown as ref@{Nth} (where Nth is the reverse-chronological index in the reflog) or as ref@{timestamp} (with the timestamp for that entry), depending on a few rules:"),
                    new GitCommandOption("-G<regex>", @"-G<regex>", @"Look for differences whose patch text contains added/removed lines that match <regex>.
To illustrate the difference between -S<regex> --pickaxe-regex and -G<regex>, consider a commit with the following diff in the same file:
+    return !regexec(regexp, two->ptr, 1, &regmatch, 0);
...
-    hit = !regexec(regexp, mf2.ptr, 1, &regmatch, 0);
While git log -G""regexec\\(regexp"" will show this commit, git log -S""regexec\\(regexp"" --pickaxe-regex will not (because the number of occurrences of that string did not change).
See the pickaxe entry in gitdiffcore[7] for more information."),
                    new GitCommandOption("--glob", @"--glob=<glob-pattern>",
                        @"Pretend as if all the refs matching shell glob <glob-pattern> are listed on the command line as <commit>. Leading refs/, is automatically prepended if missing. If pattern lacks ?, *, or [, /* at the end is implied."),
                    new GitCommandOption("--graph", @"--graph",
                        @"Draw a text-based graphical representation of the commit history on the left hand side of the output. This may cause extra lines to be printed in between commits, in order for the graph history to be drawn properly. Cannot be combined with --no-walk.
This enables parent rewriting, see History Simplification below.
This implies the --topo-order option by default, but the --date-order option may also be specified."),
                    new GitCommandOption("--grep", @"--grep=<pattern>",
                        @"Limit the commits output to ones with log message that matches the specified pattern (regular expression). With more than one --grep=<pattern>, commits whose message matches any of the given patterns are chosen (but see --all-match).
When --show-notes is in effect, the message from the notes is matched as if it were part of the log message."),
                    new GitCommandOption("--grep-reflog", @"--grep-reflog=<pattern>",
                        @"Limit the commits output to ones with reflog entries that match the specified pattern (regular expression). With more than one --grep-reflog, commits whose reflog message matches any of the given patterns are chosen. It is an error to use this option unless --walk-reflogs is in use."),
                    new GitCommandOption("--histogram", @"--histogram", @"Generate a diff using the ""histogram diff"" algorithm."),
                    new GitCommandOption("-i", @"-i", @"Match the regular expression limiting patterns without regard to letter case."),
                    new GitCommandOption("--ignore-all-space", @"--ignore-all-space",
                        @"Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other line has none."),
                    new GitCommandOption("--ignore-blank-lines", @"--ignore-blank-lines", @"Ignore changes whose lines are all blank."),
                    new GitCommandOption("--ignore-missing", @"--ignore-missing", @"Upon seeing an invalid object name in the input, pretend as if the bad input was not given."),
                    new GitCommandOption("--ignore-space-at-eol", @"--ignore-space-at-eol", @"Ignore changes in whitespace at EOL."),
                    new GitCommandOption("--ignore-space-change", @"--ignore-space-change",
                        @"Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent."),
                    new GitCommandOption("--ignore-submodules", @"--ignore-submodules[=<when>]",
                        @"Ignore changes to submodules in the diff generation. <when> can be either ""none"", ""untracked"", ""dirty"" or ""all"", which is the default. Using ""none"" will consider the submodule modified when it either contains untracked or modified files or its HEAD differs from the commit recorded in the superproject and can be used to override any settings of the ignore option in git-config[1] or gitmodules[5]. When ""untracked"" is used submodules are not considered dirty when they only contain untracked content (but they are still scanned for modified content). Using ""dirty"" ignores all changes to the work tree of submodules, only changes to the commits stored in the superproject are shown (this was the behavior until 1.7.0). Using ""all"" hides all changes to submodules."),
                    new GitCommandOption("--indent-heuristic", @"--indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--inter-hunk-context", @"--inter-hunk-context=<lines>",
                        @"Show the context between diff hunks, up to the specified number of lines, thereby fusing hunks that are close to each other."),
                    new GitCommandOption("--invert-grep", @"--invert-grep",
                        @"Limit the commits output to ones with log message that do not match the pattern specified with --grep=<pattern>."),
                    new GitCommandOption("--irreversible-delete", @"--irreversible-delete",
                        @"Omit the preimage for deletes, i.e. print only the header but not the diff between the preimage and /dev/null. The resulting patch is not meant to be applied with patch or git apply; this is solely for people who want to just concentrate on reviewing the text after the change. In addition, the output obviously lack enough information to apply such a patch in reverse, even manually, hence the name of the option.
When used together with -B, omit also the preimage in the deletion part of a delete/create pair."),
                    new GitCommandOption("--ita-invisible-in-index", @"--ita-invisible-in-index",
                        @"By default entries added by ""git add -N"" appear as an existing empty file in ""git diff"" and a new file in ""git diff --cached"". This option makes the entry appear as a new file in ""git diff"" and non-existent in ""git diff --cached"". This option could be reverted with --ita-visible-in-index. Both options are experimental and could be removed in future."),
                    new GitCommandOption("-L :<funcname>:<file>", @"-L :<funcname>:<file>",
                        @"Trace the evolution of the line range given by ""<start>,<end>"" (or the function name regex <funcname>) within the <file>. You may not give any pathspec limiters. This is currently limited to a walk starting from a single revision, i.e., you may only give zero or one positive revision arguments. You can specify this option more than once.
<start> and <end> can take one of these forms:
number
If <start> or <end> is a number, it specifies an absolute line number (lines count from 1).
/regex/
This form will use the first line matching the given POSIX regex. If <start> is a regex, it will search from the end of the previous -L range, if any, otherwise from the start of file. If <start> is '^/regex/', it will search from the start of file. If <end> is a regex, it will search starting at the line given by <start>.
+offset or -offset
This is only valid for <end> and will specify a number of lines before or after the line given by <start>.
If ':<funcname>' is given in place of <start> and <end>, it is a regular expression that denotes the range from the first funcname line that matches <funcname>, up to the next funcname line. ':<funcname>' searches from the end of the previous -L range, if any, otherwise from the start of file. '^:<funcname>' searches from the start of file."),
                    new GitCommandOption("-L,<end>:<file>", @"-L <start>,<end>:<file>",
                        @"Trace the evolution of the line range given by ""<start>,<end>"" (or the function name regex <funcname>) within the <file>. You may not give any pathspec limiters. This is currently limited to a walk starting from a single revision, i.e., you may only give zero or one positive revision arguments. You can specify this option more than once.
<start> and <end> can take one of these forms:
number
If <start> or <end> is a number, it specifies an absolute line number (lines count from 1).
/regex/
This form will use the first line matching the given POSIX regex. If <start> is a regex, it will search from the end of the previous -L range, if any, otherwise from the start of file. If <start> is '^/regex/', it will search from the start of file. If <end> is a regex, it will search starting at the line given by <start>.
+offset or -offset
This is only valid for <end> and will specify a number of lines before or after the line given by <start>.
If ':<funcname>' is given in place of <start> and <end>, it is a regular expression that denotes the range from the first funcname line that matches <funcname>, up to the next funcname line. ':<funcname>' searches from the end of the previous -L range, if any, otherwise from the start of file. '^:<funcname>' searches from the start of file."),
                    new GitCommandOption("-l<num>", @"-l<num>",
                        @"The -M and -C options require O(n^2) processing time where n is the number of potential rename/copy targets. This option prevents rename/copy detection from running if the number of rename/copy targets exceeds the specified number."),
                    new GitCommandOption("--left-only", @"--left-only",
                        @"List only commits on the respective side of a symmetric difference, i.e. only those which would be marked < resp. > by --left-right.
For example, --cherry-pick --right-only A...B omits those commits from B which are in A or are patch-equivalent to a commit in A. In other words, this lists the + commits from git cherry A B. More precisely, --cherry-pick --right-only --no-merges gives the exact list."),
                    new GitCommandOption("--left-right", @"--left-right",
                        @"Mark which side of a symmetric difference a commit is reachable from. Commits from the left side are prefixed with < and those from the right with >. If combined with --boundary, those commits are prefixed with -.
For example, if you have this topology:
	     y---b---b  branch B
	    / \\ /
	   /   .
	  /   / \\
	 o---x---a---a  branch A
you would get an output like this:
	$ git rev-list --left-right --boundary --pretty=oneline A...B
	>bbbbbbb... 3rd on b
	>bbbbbbb... 2nd on b
	<aaaaaaa... 3rd on a
	<aaaaaaa... 2nd on a
	-yyyyyyy... 1st on b
	-xxxxxxx... 1st on a"),
                    new GitCommandOption("--line-prefix", @"--line-prefix=<prefix>", @"Prepend an additional prefix to every line of output."),
                    new GitCommandOption("--log-size", @"--log-size",
                        @"Include a line 'log size <number>' in the output for each commit, where <number> is the length of that commit''s message in bytes. Intended to speed up tools that read log messages from git log output by allowing them to allocate space in advance."),
                    new GitCommandOption("-m", @"-m",
                        @"This flag makes the merge commits show the full diff like regular commits; for each merge parent, a separate log entry and diff is generated. An exception is that only diff against the first parent is shown when --first-parent option is given; in that case, the output represents the changes the merge brought into the then-current branch."),
                    new GitCommandOption("-M[<n>]", @"-M[<n>]",
                        @"If generating diffs, detect and report renames for each commit. For following files across renames while traversing history, see --follow. If n is specified, it is a threshold on the similarity index (i.e. amount of addition/deletions compared to the file''s size). For example, -M90% means Git should consider a delete/add pair to be a rename if more than 90% of the file hasn''t changed. Without a % sign, the number is to be read as a fraction, with a decimal point before it. I.e., -M5 becomes 0.5, and is thus the same as -M50%. Similarly, -M05 is the same as -M5%. To limit detection to exact renames, use -M100%. The default similarity index is 50%."),
                    new GitCommandOption("--max-count", @"--max-count=<number>", @"Limit the number of commits to output."), new GitCommandOption("--max-parents", @"--max-parents=<number>",
                        @"Show only commits which have at least (or at most) that many parent commits. In particular, --max-parents=1 is the same as --no-merges, --min-parents=2 is the same as --merges. --max-parents=0 gives all root commits and --min-parents=3 all octopus merges.
--no-min-parents and --no-max-parents reset these limits (to no limit) again. Equivalent forms are --min-parents=0 (any commit has 0 or more parents) and --max-parents=-1 (negative numbers denote no upper limit)."),
                    new GitCommandOption("--merge", @"--merge", @"After a failed merge, show refs that touch files having a conflict and don't exist on all heads to merge."),
                    new GitCommandOption("--merges", @"--merges", @"Print only merge commits. This is exactly the same as --min-parents=2."),
                    new GitCommandOption("--minimal", @"--minimal", @"Spend extra time to make sure the smallest possible diff is produced."), new GitCommandOption("--min-parents",
                        @"--min-parents=<number>",
                        @"Show only commits which have at least (or at most) that many parent commits. In particular, --max-parents=1 is the same as --no-merges, --min-parents=2 is the same as --merges. --max-parents=0 gives all root commits and --min-parents=3 all octopus merges.
--no-min-parents and --no-max-parents reset these limits (to no limit) again. Equivalent forms are --min-parents=0 (any commit has 0 or more parents) and --max-parents=-1 (negative numbers denote no upper limit)."),
                    new GitCommandOption("-n", @"-n <number>", @"Limit the number of commits to output."),
                    new GitCommandOption("--name-only", @"--name-only", @"Show only names of changed files."),
                    new GitCommandOption("--name-status", @"--name-status",
                        @"Show only names and status of changed files. See the description of the --diff-filter option on what the status letters mean."),
                    new GitCommandOption("--no-abbrev-commit", @"--no-abbrev-commit",
                        @"Show the full 40-byte hexadecimal commit object name. This negates --abbrev-commit and those options which imply it such as ""--oneline"". It also overrides the log.abbrevCommit variable."),
                    new GitCommandOption("--no-color", @"--no-color", @"Turn off colored diff. It is the same as --color=never."),
                    new GitCommandOption("--no-compaction-heuristic", @"--no-compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-decorate", @"--no-decorate",
                        @"Print out the ref names of any commits that are shown. If short is specified, the ref name prefixes refs/heads/, refs/tags/ and refs/remotes/ will not be printed. If full is specified, the full ref name (including prefix) will be printed. If auto is specified, then if the output is going to a terminal, the ref names are shown as if short were given, otherwise no ref names are shown. The default option is short."),
                    new GitCommandOption("--no-expand-tabs", @"--no-expand-tabs",
                        @"Perform a tab expansion (replace each tab with enough spaces to fill to the next display column that is multiple of <n>) in the log message before showing it in the output. --expand-tabs is a short-hand for --expand-tabs=8, and --no-expand-tabs is a short-hand for --expand-tabs=0, which disables tab expansion.
By default, tabs are expanded in pretty formats that indent the log message by 4 spaces (i.e. medium, which is the default, full, and fuller)."),
                    new GitCommandOption("--no-ext-diff", @"--no-ext-diff", @"Disallow external diff drivers."),
                    new GitCommandOption("--no-indent-heuristic", @"--no-indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-max-parents", @"--no-max-parents",
                        @"Show only commits which have at least (or at most) that many parent commits. In particular, --max-parents=1 is the same as --no-merges, --min-parents=2 is the same as --merges. --max-parents=0 gives all root commits and --min-parents=3 all octopus merges.
--no-min-parents and --no-max-parents reset these limits (to no limit) again. Equivalent forms are --min-parents=0 (any commit has 0 or more parents) and --max-parents=-1 (negative numbers denote no upper limit)."),
                    new GitCommandOption("--no-merges", @"--no-merges", @"Do not print commits with more than one parent. This is exactly the same as --max-parents=1."),
                    new GitCommandOption("--no-min-parents", @"--no-min-parents",
                        @"Show only commits which have at least (or at most) that many parent commits. In particular, --max-parents=1 is the same as --no-merges, --min-parents=2 is the same as --merges. --max-parents=0 gives all root commits and --min-parents=3 all octopus merges.
--no-min-parents and --no-max-parents reset these limits (to no limit) again. Equivalent forms are --min-parents=0 (any commit has 0 or more parents) and --max-parents=-1 (negative numbers denote no upper limit)."),
                    new GitCommandOption("--no-notes", @"--no-notes",
                        @"Do not show notes. This negates the above --notes option, by resetting the list of notes refs from which notes are shown. Options are parsed in the order given on the command line, so e.g. ""--notes --notes=foo --no-notes --notes=bar"" will only show notes from ""refs/notes/bar""."),
                    new GitCommandOption("--no-patch", @"--no-patch",
                        @"Suppress diff output. Useful for commands like git show that show the patch by default, or to cancel the effect of --patch."),
                    new GitCommandOption("--no-prefix", @"--no-prefix", @"Do not show any source or destination prefix."),
                    new GitCommandOption("--no-renames", @"--no-renames", @"Turn off rename detection, even when the configuration file gives the default to do so."),
                    new GitCommandOption("--not", @"--not", @"Reverses the meaning of the ^ prefix (or lack thereof) for all following revision specifiers, up to the next --not."),
                    new GitCommandOption("--notes", @"--notes[=<treeish>]",
                        @"Show the notes (see git-notes[1]) that annotate the commit, when showing the commit log message. This is the default for git log, git show and git whatchanged commands when there is no --pretty, --format, or --oneline option given on the command line.
By default, the notes shown are from the notes refs listed in the core.notesRef and notes.displayRef variables (or corresponding environment overrides). See git-config[1] for more details.
With an optional <treeish> argument, use the treeish to find the notes to display. The treeish can specify the full refname when it begins with refs/notes/; when it begins with notes/, refs/ and otherwise refs/notes/ is prefixed to form a full name of the ref.
Multiple --notes options can be combined to control which notes are being displayed. Examples: ""--notes=foo"" will show only notes from ""refs/notes/foo""; ""--notes=foo --notes"" will show both notes from ""refs/notes/foo"" and from the default notes ref(s)."),
                    new GitCommandOption("--no-textconv", @"--no-textconv",
                        @"Allow (or disallow) external text conversion filters to be run when comparing binary files. See gitattributes[5] for details. Because textconv filters are typically a one-way conversion, the resulting diff is suitable for human consumption, but cannot be applied. For this reason, textconv filters are enabled by default only for git-diff[1] and git-log[1], but not for git-format-patch[1] or diff plumbing commands."),
                    new GitCommandOption("--no-walk[=(sorted|unsorted)]", @"--no-walk[=(sorted|unsorted)]",
                        @"Only show the given commits, but do not traverse their ancestors. This has no effect if a range is specified. If the argument unsorted is given, the commits are shown in the order they were given on the command line. Otherwise (if sorted or no argument was given), the commits are shown in reverse chronological order by commit time. Cannot be combined with --graph."),
                    new GitCommandOption("--numstat", @"--numstat",
                        @"Similar to --stat, but shows number of added and deleted lines in decimal notation and pathname without abbreviation, to make it more machine friendly. For binary files, outputs two - instead of saying 0 0."),
                    new GitCommandOption("-O<orderfile>", @"-O<orderfile>",
                        @"Output the patch in the order specified in the <orderfile>, which has one shell glob pattern per line. This overrides the diff.orderFile configuration variable (see git-config[1]). To cancel diff.orderFile, use -O/dev/null."),
                    new GitCommandOption("--oneline", @"--oneline", @"This is a shorthand for ""--pretty=oneline --abbrev-commit"" used together."),
                    new GitCommandOption("-p", @"-p", @"Generate patch (see section on generating patches)."),
                    new GitCommandOption("--parents", @"--parents",
                        @"Print also the parents of the commit (in the form ""commit parent...""). Also enables parent rewriting, see History Simplification below."),
                    new GitCommandOption("--patch", @"--patch", @"Generate patch (see section on generating patches)."),
                    new GitCommandOption("--patch-with-raw", @"--patch-with-raw", @"Synonym for -p --raw."),
                    new GitCommandOption("--patch-with-stat", @"--patch-with-stat", @"Synonym for -p --stat."),
                    new GitCommandOption("--patience", @"--patience", @"Generate a diff using the ""patience diff"" algorithm."),
                    new GitCommandOption("--perl-regexp", @"--perl-regexp", @"Consider the limiting patterns to be Perl-compatible regular expressions. Requires libpcre to be compiled in."),
                    new GitCommandOption("--pickaxe-all", @"--pickaxe-all",
                        @"When -S or -G finds a change, show all the changes in that changeset, not just the files that contain the change in <string>."),
                    new GitCommandOption("--pickaxe-regex", @"--pickaxe-regex", @"Treat the <string> given to -S as an extended POSIX regular expression to match."), new GitCommandOption(
                        "--pretty", @"--pretty[=<format>]",
                        @"Pretty-print the contents of the commit logs in a given format, where <format> can be one of oneline, short, medium, full, fuller, email, raw, format:<string> and tformat:<string>. When <format> is none of the above, and has %placeholder in it, it acts as if --pretty=tformat:<format> were given.
See the ""PRETTY FORMATS"" section for some additional details for each format. When =<format> part is omitted, it defaults to medium.
Note: you can specify the default pretty format in the repository configuration (see git-config[1])."),
                    new GitCommandOption("-R", @"-R", @"Swap two inputs; that is, show differences from index or on-disk file to tree contents."),
                    new GitCommandOption("-r", @"-r", @"Show recursive diffs."),
                    new GitCommandOption("--raw", @"--raw",
                        @"For each commit, show a summary of changes using the raw diff format. See the ""RAW OUTPUT FORMAT"" section of git-diff[1]. This is different from showing the log itself in raw format, which you can achieve with --format=raw."),
                    new GitCommandOption("--reflog", @"--reflog", @"Pretend as if all objects mentioned by reflogs are listed on the command line as <commit>."),
                    new GitCommandOption("--regexp-ignore-case", @"--regexp-ignore-case", @"Match the regular expression limiting patterns without regard to letter case."),
                    new GitCommandOption("--relative", @"--relative[=<path>]",
                        @"When run from a subdirectory of the project, it can be told to exclude changes outside the directory and show pathnames relative to it with this option. When you are not in a subdirectory (e.g. in a bare repository), you can name which subdirectory to make the output relative to by giving a <path> as an argument."),
                    new GitCommandOption("--relative-date", @"--relative-date", @"Synonym for --date=relative."),
                    new GitCommandOption("--remotes", @"--remotes[=<pattern>]",
                        @"Pretend as if all the refs in refs/remotes are listed on the command line as <commit>. If <pattern> is given, limit remote-tracking branches to ones matching given shell glob. If pattern lacks ?, *, or [, /* at the end is implied."),
                    new GitCommandOption("--remove-empty", @"--remove-empty", @"Stop when a given path disappears from the tree."),
                    new GitCommandOption("--reverse", @"--reverse",
                        @"Output the commits chosen to be shown (see Commit Limiting section above) in reverse order. Cannot be combined with --walk-reflogs."),
                    new GitCommandOption("--right-only", @"--right-only",
                        @"List only commits on the respective side of a symmetric difference, i.e. only those which would be marked < resp. > by --left-right.
For example, --cherry-pick --right-only A...B omits those commits from B which are in A or are patch-equivalent to a commit in A. In other words, this lists the + commits from git cherry A B. More precisely, --cherry-pick --right-only --no-merges gives the exact list."),
                    new GitCommandOption("-s", @"-s", @"Suppress diff output. Useful for commands like git show that show the patch by default, or to cancel the effect of --patch."),
                    new GitCommandOption("-S<string>", @"-S<string>",
                        @"Look for differences that change the number of occurrences of the specified string (i.e. addition/deletion) in a file. Intended for the scripter''s use.
It is useful when you''re looking for an exact block of code (like a struct), and want to know the history of that block since it first came into being: use the feature iteratively to feed the interesting block in the preimage back into -S, and keep going until you get the very first version of the block."),
                    new GitCommandOption("--shortstat", @"--shortstat",
                        @"Output only the last line of the --stat format containing total number of modified files, as well as number of added and deleted lines."),
                    new GitCommandOption("--show-linear-break", @"--show-linear-break[=<barrier>]",
                        @"When --graph is not used, all history branches are flattened which can make it hard to see that the two consecutive commits do not belong to a linear branch. This option puts a barrier in between them in that case. If <barrier> is specified, it is the string that will be shown instead of the default one."),
                    new GitCommandOption("--show-notes", @"--show-notes[=<treeish>]", @"These options are deprecated. Use the above --notes/--no-notes options instead."),
                    new GitCommandOption("--show-signature", @"--show-signature",
                        @"Check the validity of a signed commit object by passing the signature to gpg --verify and show the output."),
                    new GitCommandOption("--simplify-by-decoration", @"--simplify-by-decoration", @"Commits that are referred by some branch or tag are selected."), new GitCommandOption(
                        "--simplify-merges", @"--simplify-merges", @"First, build a history graph in the same way that --full-history with parent rewriting does (see above).
Then simplify each commit C to its replacement C'' in the final history according to the following rules:
Set C'' to C.
Replace each parent P of C'' with its simplification P''. In the process, drop parents that are ancestors of other parents or that are root commits TREESAME to an empty tree, and remove duplicates, but take care to never drop all parents that we are TREESAME to.
If after this parent rewriting, C'' is a root or merge commit (has zero or >1 parents), a boundary commit, or !TREESAME, it remains. Otherwise, it is replaced with its only parent.
The effect of this is best shown by way of comparing to --full-history with parent rewriting. The example turns into:
	  .-A---M---N---O
	 /     /       /
	I     B       D
	 \\   /       /
	  `---------''
Note the major differences in N, P, and Q over --full-history:
N''s parent list had I removed, because it is an ancestor of the other parent M. Still, N remained because it is !TREESAME.
P''s parent list similarly had I removed. P was then removed completely, because it had one parent and is TREESAME.
Q''s parent list had Y simplified to X. X was then removed, because it was a TREESAME root. Q was then removed completely, because it had one parent and is TREESAME."),
                    new GitCommandOption("--simplify-merges", @"--simplify-merges",
                        @"Additional option to --full-history to remove some needless merges from the resulting history, as there are no selected commits contributing to this merge."),
                    new GitCommandOption("--since", @"--since=<date>", @"Show commits more recent than a specific date."),
                    new GitCommandOption("--skip", @"--skip=<number>", @"Skip number commits before starting to show the commit output."),
                    new GitCommandOption("--source", @"--source", @"Print out the ref name given on the command line by which each commit was reached."),
                    new GitCommandOption("--sparse", @"--sparse", @"All commits in the simplified history are shown."), new GitCommandOption("--sparse", @"--sparse",
                        @"All commits that are walked are included.
Note that without --full-history, this still simplifies merges: if one of the parents is TREESAME, we follow only that one, so the other sides of the merge are never walked."),
                    new GitCommandOption("--src-prefix", @"--src-prefix=<prefix>", @"Show the given source prefix instead of ""a/""."), new GitCommandOption(
                        "--stat[[,<name-width>[,<count>]]]", @"--stat[=<width>[,<name-width>[,<count>]]]",
                        @"Generate a diffstat. By default, as much space as necessary will be used for the filename part, and the rest for the graph part. Maximum width defaults to terminal width, or 80 columns if not connected to a terminal, and can be overridden by <width>. The width of the filename part can be limited by giving another width <name-width> after a comma. The width of the graph part can be limited by using --stat-graph-width=<width> (affects all commands generating a stat graph) or by setting diff.statGraphWidth=<width> (does not affect git format-patch). By giving a third parameter <count>, you can limit the output to the first <count> lines, followed by ... if there are more.
These parameters can also be set individually with --stat-width=<width>, --stat-name-width=<name-width> and --stat-count=<count>."),
                    new GitCommandOption("--stdin", @"--stdin",
                        @"In addition to the <commit> listed on the command line, read them from the standard input. If a -- separator is seen, stop reading commits and start reading paths to limit the result."),
                    new GitCommandOption("--submodule", @"--submodule[=<format>]",
                        @"Specify how differences in submodules are shown. When specifying --submodule=short the short format is used. This format just shows the names of the commits at the beginning and end of the range. When --submodule or --submodule=log is specified, the log format is used. This format lists the commits in the range like git-submodule[1] summary does. When --submodule=diff is specified, the diff format is used. This format shows an inline diff of the changes in the submodule contents between the commit range. Defaults to diff.submodule or the short format if the config option is unset."),
                    new GitCommandOption("--summary", @"--summary", @"Output a condensed summary of extended header information such as creations, renames and mode changes."),
                    new GitCommandOption("-t", @"-t", @"Show the tree objects in the diff output. This implies -r."),
                    new GitCommandOption("--tags", @"--tags[=<pattern>]",
                        @"Pretend as if all the refs in refs/tags are listed on the command line as <commit>. If <pattern> is given, limit tags to ones matching given shell glob. If pattern lacks ?, *, or [, /* at the end is implied."),
                    new GitCommandOption("--text", @"--text", @"Treat all files as text."),
                    new GitCommandOption("--textconv", @"--textconv",
                        @"Allow (or disallow) external text conversion filters to be run when comparing binary files. See gitattributes[5] for details. Because textconv filters are typically a one-way conversion, the resulting diff is suitable for human consumption, but cannot be applied. For this reason, textconv filters are enabled by default only for git-diff[1] and git-log[1], but not for git-format-patch[1] or diff plumbing commands."),
                    new GitCommandOption("--topo-order", @"--topo-order",
                        @"Show no parents before all of its children are shown, and avoid showing commits on multiple lines of history intermixed.
For example, in a commit history like this:
    ---1----2----4----7
	\\	       \\
	 3----5----6----8---
where the numbers denote the order of commit timestamps, git rev-list and friends with --date-order show the commits in the timestamp order: 8 7 6 5 4 3 2 1.
With --topo-order, they would show 8 6 5 3 7 4 2 1 (or 8 7 4 2 6 5 3 1); some older commits are shown before newer ones in order to avoid showing the commits from two parallel development track mixed together."),
                    new GitCommandOption("-u", @"-u", @"Generate patch (see section on generating patches)."),
                    new GitCommandOption("-U<n>", @"-U<n>", @"Generate diffs with <n> lines of context instead of the usual three. Implies -p."),
                    new GitCommandOption("--unified", @"--unified=<n>", @"Generate diffs with <n> lines of context instead of the usual three. Implies -p."),
                    new GitCommandOption("--until", @"--until=<date>", @"Show commits older than a specific date."),
                    new GitCommandOption("--use-mailmap", @"--use-mailmap",
                        @"Use mailmap file to map author and committer names and email addresses to canonical real names and email addresses. See git-shortlog[1]."),
                    new GitCommandOption("-W", @"-W", @"Show whole surrounding functions of changes."),
                    new GitCommandOption("-w", @"-w", @"Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other line has none."),
                    new GitCommandOption("--walk-reflogs", @"--walk-reflogs",
                        @"Instead of walking the commit ancestry chain, walk reflog entries from the most recent one to older ones. When this option is used you cannot specify commits to exclude (that is, ^commit, commit1..commit2, and commit1...commit2 notations cannot be used).
With --pretty format other than oneline (for obvious reasons), this causes the output to have two extra lines of information taken from the reflog. The reflog designator in the output may be shown as ref@{Nth} (where Nth is the reverse-chronological index in the reflog) or as ref@{timestamp} (with the timestamp for that entry), depending on a few rules:"),
                    new GitCommandOption("--word-diff", @"--word-diff[=<mode>]",
                        @"Show a word diff, using the <mode> to delimit changed words. By default, words are delimited by whitespace; see --word-diff-regex below. The <mode> defaults to plain, and must be one of:
color
Highlight changed words using only colors. Implies --color.
plain
Show words as [-removed-] and {+added+}. Makes no attempts to escape the delimiters if they appear in the input, so the output may be ambiguous.
porcelain
Use a special line-based format intended for script consumption. Added/removed/unchanged runs are printed in the usual unified diff format, starting with a +/-/` ` character at the beginning of the line and extending to the end of the line. Newlines in the input are represented by a tilde ~ on a line of its own.
none
Disable word diff again.
Note that despite the name of the first mode, color is used to highlight the changed parts in all modes if enabled."),
                    new GitCommandOption("--word-diff-regex",
                        @"--word-diff-regex=<regex>",
                        @"Use <regex> to decide what a word is, instead of considering runs of non-whitespace to be a word. Also implies --word-diff unless it was already enabled.
Every non-overlapping match of the <regex> is considered a word. Anything between these matches is considered whitespace and ignored(!) for the purposes of finding differences. You may want to append |[^[:space:]] to your regular expression to make sure that it matches all non-whitespace characters. A match that contains a newline is silently truncated(!) at the newline.
For example, --word-diff-regex=. will treat each character as a word and, correspondingly, show differences character by character.
The regex can also be set via a diff driver or configuration option, see gitattributes[5] or git-config[1]. Giving it explicitly overrides any diff driver or configuration setting. Diff drivers override configuration settings."),
                    new GitCommandOption("--ws-error-highlight", @"--ws-error-highlight=<kind>",
                        @"Highlight whitespace errors on lines specified by <kind> in the color specified by color.diff.whitespace. <kind> is a comma separated list of old, new, context. When this option is not given, only whitespace errors in new lines are highlighted. E.g. --ws-error-highlight=new,old highlights whitespace errors on both deleted and added lines. all can be used as a short-hand for old,new,context. The diff.wsErrorHighlight configuration variable can be used to specify the default behaviour."),
                    new GitCommandOption("-z", @"-z", @"Separate the commits with NULs instead of with new newlines.
Also, when --raw or --numstat has been given, do not munge pathnames and use NULs as output field terminators.
Without this option, each pathname output will have TAB, LF, double quotes, and backslash characters replaced with \\t, \\n, \\"", and \\\\, respectively, and the pathname will be enclosed in double quotes if any of those replacements occurred.")
                },
                "merge" => new[]
                {
                    new GitCommandOption("--[no-]rerere-autoupdate", @"--[no-]rerere-autoupdate",
                        @"Allow the rerere mechanism to update the index with the result of auto-conflict resolution if possible."),
                    new GitCommandOption("--abort", @"--abort",
                        @"Abort the current conflict resolution process, and try to reconstruct the pre-merge state.
If there were uncommitted worktree changes present when the merge started, git merge --abort will in some cases be unable to reconstruct these changes. It is therefore recommended to always commit or stash your changes before running git merge.
git merge --abort is equivalent to git reset --merge when MERGE_HEAD is present."),
                    new GitCommandOption("--allow-unrelated-histories", @"--allow-unrelated-histories",
                        @"By default, git merge command refuses to merge histories that do not share a common ancestor. This option can be used to override this safety when merging histories of two projects that started their lives independently. As that is a very rare occasion, no configuration variable to enable this by default exists and will not be added."),
                    new GitCommandOption("--commit", @"--commit", @"Perform the merge and commit the result. This option can be used to override --no-commit.
With --no-commit perform the merge but pretend the merge failed and do not autocommit, to give the user a chance to inspect and further tweak the merge result before committing."),
                    new GitCommandOption("-e", @"-e",
                        @"Invoke an editor before committing successful mechanical merge to further edit the auto-generated merge message, so that the user can explain and justify the merge. The --no-edit option can be used to accept the auto-generated message (this is generally discouraged). The --edit (or -e) option is still useful if you are giving a draft message with the -m option from the command line and want to edit it in the editor.
Older scripts may depend on the historical behaviour of not allowing the user to edit the merge log message. They will see an editor opened when they run git merge. To make it easier to adjust such scripts to the updated behaviour, the environment variable GIT_MERGE_AUTOEDIT can be set to no at the beginning of them."),
                    new GitCommandOption("--edit", @"--edit",
                        @"Invoke an editor before committing successful mechanical merge to further edit the auto-generated merge message, so that the user can explain and justify the merge. The --no-edit option can be used to accept the auto-generated message (this is generally discouraged). The --edit (or -e) option is still useful if you are giving a draft message with the -m option from the command line and want to edit it in the editor.
Older scripts may depend on the historical behaviour of not allowing the user to edit the merge log message. They will see an editor opened when they run git merge. To make it easier to adjust such scripts to the updated behaviour, the environment variable GIT_MERGE_AUTOEDIT can be set to no at the beginning of them."),
                    new GitCommandOption("--ff", @"--ff",
                        @"When the merge resolves as a fast-forward, only update the branch pointer, without creating a merge commit. This is the default behavior."),
                    new GitCommandOption("--ff-only", @"--ff-only",
                        @"Refuse to merge and exit with a non-zero status unless the current HEAD is already up-to-date or the merge can be resolved as a fast-forward."),
                    new GitCommandOption("--gpg-sign", @"--gpg-sign[=<keyid>]",
                        @"GPG-sign the resulting merge commit. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("--log", @"--log[=<n>]",
                        @"In addition to branch names, populate the log message with one-line descriptions from at most <n> actual commits that are being merged. See also git-fmt-merge-msg[1].
With --no-log do not list one-line descriptions from the actual commits being merged."),
                    new GitCommandOption("-m", @"-m <msg>", @"Set the commit message to be used for the merge commit (in case one is created).
If --log is specified, a shortlog of the commits being merged will be appended to the specified message.
The git fmt-merge-msg command can be used to give a good default for automated git merge invocations. The automated message can include the branch description."),
                    new GitCommandOption("-n", @"-n", @"Show a diffstat at the end of the merge. The diffstat is also controlled by the configuration option merge.stat.
With -n or --no-stat do not show a diffstat at the end of the merge."),
                    new GitCommandOption("--no-commit", @"--no-commit", @"Perform the merge and commit the result. This option can be used to override --no-commit.
With --no-commit perform the merge but pretend the merge failed and do not autocommit, to give the user a chance to inspect and further tweak the merge result before committing."),
                    new GitCommandOption("--no-edit", @"--no-edit",
                        @"Invoke an editor before committing successful mechanical merge to further edit the auto-generated merge message, so that the user can explain and justify the merge. The --no-edit option can be used to accept the auto-generated message (this is generally discouraged). The --edit (or -e) option is still useful if you are giving a draft message with the -m option from the command line and want to edit it in the editor.
Older scripts may depend on the historical behaviour of not allowing the user to edit the merge log message. They will see an editor opened when they run git merge. To make it easier to adjust such scripts to the updated behaviour, the environment variable GIT_MERGE_AUTOEDIT can be set to no at the beginning of them."),
                    new GitCommandOption("--no-ff", @"--no-ff",
                        @"Create a merge commit even when the merge resolves as a fast-forward. This is the default behaviour when merging an annotated (and possibly signed) tag."),
                    new GitCommandOption("--no-log", @"--no-log",
                        @"In addition to branch names, populate the log message with one-line descriptions from at most <n> actual commits that are being merged. See also git-fmt-merge-msg[1].
With --no-log do not list one-line descriptions from the actual commits being merged."),
                    new GitCommandOption("--no-progress", @"--no-progress",
                        @"Turn progress on/off explicitly. If neither is specified, progress is shown if standard error is connected to a terminal. Note that not all merge strategies may support progress reporting."),
                    new GitCommandOption("--no-squash", @"--no-squash",
                        @"Produce the working tree and index state as if a real merge happened (except for the merge information), but do not actually make a commit, move the HEAD, or record $GIT_DIR/MERGE_HEAD (to cause the next git commit command to create a merge commit). This allows you to create a single commit on top of the current branch whose effect is the same as merging another branch (or more in case of an octopus).
With --no-squash perform the merge and commit the result. This option can be used to override --squash."),
                    new GitCommandOption("--no-stat", @"--no-stat",
                        @"Show a diffstat at the end of the merge. The diffstat is also controlled by the configuration option merge.stat.
With -n or --no-stat do not show a diffstat at the end of the merge."),
                    new GitCommandOption("--no-summary", @"--no-summary", @"Synonyms to --stat and --no-stat; these are deprecated and will be removed in the future."),
                    new GitCommandOption("--no-verify-signatures", @"--no-verify-signatures",
                        @"Verify that the tip commit of the side branch being merged is signed with a valid key, i.e. a key that has a valid uid: in the default trust model, this means the signing key has been signed by a trusted key. If the tip commit of the side branch is not signed with a valid key, the merge is aborted."),
                    new GitCommandOption("--progress", @"--progress",
                        @"Turn progress on/off explicitly. If neither is specified, progress is shown if standard error is connected to a terminal. Note that not all merge strategies may support progress reporting."),
                    new GitCommandOption("-q", @"-q", @"Operate quietly. Implies --no-progress."), new GitCommandOption("--quiet", @"--quiet", @"Operate quietly. Implies --no-progress."),
                    new GitCommandOption("-s", @"-s <strategy>",
                        @"Use the given merge strategy; can be supplied more than once to specify them in the order they should be tried. If there is no -s option, a built-in list of strategies is used instead (git merge-recursive when merging a single head, git merge-octopus otherwise)."),
                    new GitCommandOption("-S[<keyid>]", @"-S[<keyid>]",
                        @"GPG-sign the resulting merge commit. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("--squash", @"--squash",
                        @"Produce the working tree and index state as if a real merge happened (except for the merge information), but do not actually make a commit, move the HEAD, or record $GIT_DIR/MERGE_HEAD (to cause the next git commit command to create a merge commit). This allows you to create a single commit on top of the current branch whose effect is the same as merging another branch (or more in case of an octopus).
With --no-squash perform the merge and commit the result. This option can be used to override --squash."),
                    new GitCommandOption("--stat", @"--stat", @"Show a diffstat at the end of the merge. The diffstat is also controlled by the configuration option merge.stat.
With -n or --no-stat do not show a diffstat at the end of the merge."),
                    new GitCommandOption("--strategy", @"--strategy=<strategy>",
                        @"Use the given merge strategy; can be supplied more than once to specify them in the order they should be tried. If there is no -s option, a built-in list of strategies is used instead (git merge-recursive when merging a single head, git merge-octopus otherwise)."),
                    new GitCommandOption("--strategy-option", @"--strategy-option=<option>", @"Pass merge strategy specific option through to the merge strategy."),
                    new GitCommandOption("--summary", @"--summary", @"Synonyms to --stat and --no-stat; these are deprecated and will be removed in the future."),
                    new GitCommandOption("-v", @"-v", @"Be verbose."), new GitCommandOption("--verbose", @"--verbose", @"Be verbose."),
                    new GitCommandOption("--verify-signatures", @"--verify-signatures",
                        @"Verify that the tip commit of the side branch being merged is signed with a valid key, i.e. a key that has a valid uid: in the default trust model, this means the signing key has been signed by a trusted key. If the tip commit of the side branch is not signed with a valid key, the merge is aborted."),
                    new GitCommandOption("-X", @"-X <option>", @"Pass merge strategy specific option through to the merge strategy.")
                },
                "mergetool" => new[]
                {
                    new GitCommandOption("--no-prompt", @"--no-prompt",
                        @"Don''t prompt before each invocation of the merge resolution program. This is the default if the merge resolution program is explicitly specified with the --tool option or with the merge.tool configuration variable."),
                    new GitCommandOption("-O<orderfile>", @"-O<orderfile>",
                        @"Process files in the order specified in the <orderfile>, which has one shell glob pattern per line. This overrides the diff.orderFile configuration variable (see git-config[1]). To cancel diff.orderFile, use -O/dev/null."),
                    new GitCommandOption("--prompt", @"--prompt", @"Prompt before each invocation of the merge resolution program to give the user a chance to skip the path."),
                    new GitCommandOption("-t", @"-t <tool>",
                        @"Use the merge resolution program specified by <tool>. Valid values include emerge, gvimdiff, kdiff3, meld, vimdiff, and tortoisemerge. Run git mergetool --tool-help for the list of valid <tool> settings.
If a merge resolution program is not specified, git mergetool will use the configuration variable merge.tool. If the configuration variable merge.tool is not set, git mergetool will pick a suitable default.
You can explicitly provide a full path to the tool by setting the configuration variable mergetool.<tool>.path. For example, you can configure the absolute path to kdiff3 by setting mergetool.kdiff3.path. Otherwise, git mergetool assumes the tool is available in PATH.
Instead of running one of the known merge tool programs, git mergetool can be customized to run an alternative program by specifying the command line to invoke in a configuration variable mergetool.<tool>.cmd.
When git mergetool is invoked with this tool (either through the -t or --tool option or the merge.tool configuration variable) the configured command line will be invoked with $BASE set to the name of a temporary file containing the common base for the merge, if available; $LOCAL set to the name of a temporary file containing the contents of the file on the current branch; $REMOTE set to the name of a temporary file containing the contents of the file to be merged, and $MERGED set to the name of the file to which the merge tool should write the result of the merge resolution.
If the custom merge tool correctly indicates the success of a merge resolution with its exit code, then the configuration variable mergetool.<tool>.trustExitCode can be set to true. Otherwise, git mergetool will prompt the user to indicate the success of the resolution after the custom tool has exited."),
                    new GitCommandOption("--tool", @"--tool=<tool>",
                        @"Use the merge resolution program specified by <tool>. Valid values include emerge, gvimdiff, kdiff3, meld, vimdiff, and tortoisemerge. Run git mergetool --tool-help for the list of valid <tool> settings.
If a merge resolution program is not specified, git mergetool will use the configuration variable merge.tool. If the configuration variable merge.tool is not set, git mergetool will pick a suitable default.
You can explicitly provide a full path to the tool by setting the configuration variable mergetool.<tool>.path. For example, you can configure the absolute path to kdiff3 by setting mergetool.kdiff3.path. Otherwise, git mergetool assumes the tool is available in PATH.
Instead of running one of the known merge tool programs, git mergetool can be customized to run an alternative program by specifying the command line to invoke in a configuration variable mergetool.<tool>.cmd.
When git mergetool is invoked with this tool (either through the -t or --tool option or the merge.tool configuration variable) the configured command line will be invoked with $BASE set to the name of a temporary file containing the common base for the merge, if available; $LOCAL set to the name of a temporary file containing the contents of the file on the current branch; $REMOTE set to the name of a temporary file containing the contents of the file to be merged, and $MERGED set to the name of the file to which the merge tool should write the result of the merge resolution.
If the custom merge tool correctly indicates the success of a merge resolution with its exit code, then the configuration variable mergetool.<tool>.trustExitCode can be set to true. Otherwise, git mergetool will prompt the user to indicate the success of the resolution after the custom tool has exited."),
                    new GitCommandOption("--tool-help", @"--tool-help", @"Print a list of merge tools that may be used with --tool."),
                    new GitCommandOption("-y", @"-y",
                        @"Don''t prompt before each invocation of the merge resolution program. This is the default if the merge resolution program is explicitly specified with the --tool option or with the merge.tool configuration variable.")
                },
                "mv" => new[]
                {
                    new GitCommandOption("--dry-run", @"--dry-run", @"Do nothing; only show what would happen"),
                    new GitCommandOption("-f", @"-f", @"Force renaming or moving of a file even if the target exists"),
                    new GitCommandOption("--force", @"--force", @"Force renaming or moving of a file even if the target exists"),
                    new GitCommandOption("-k", @"-k",
                        @"Skip move or rename actions which would lead to an error condition. An error happens when a source is neither existing nor controlled by Git, or when it would overwrite an existing file unless -f is given."),
                    new GitCommandOption("-n", @"-n", @"Do nothing; only show what would happen"), new GitCommandOption("-v", @"-v", @"Report the names of files as they are moved."),
                    new GitCommandOption("--verbose", @"--verbose", @"Report the names of files as they are moved.")
                },
                "notes" => new[]
                {
                    new GitCommandOption("--abort", @"--abort",
                        @"Abort/reset a in-progress git notes merge, i.e. a notes merge with conflicts. This simply removes all files related to the notes merge."),
                    new GitCommandOption("--allow-empty", @"--allow-empty", @"Allow an empty note object to be stored. The default behavior is to automatically remove empty notes."),
                    new GitCommandOption("-c", @"-c <object>", @"Like -C, but with -c the editor is invoked, so that the user can further edit the note message."),
                    new GitCommandOption("-C", @"-C <object>",
                        @"Take the given blob object (for example, another note) as the note message. (Use git notes copy <object> instead to copy notes between objects.)"),
                    new GitCommandOption("--commit", @"--commit",
                        @"Finalize an in-progress git notes merge. Use this option when you have resolved the conflicts that git notes merge stored in .git/NOTES_MERGE_WORKTREE. This amends the partial merge commit created by git notes merge (stored in .git/NOTES_MERGE_PARTIAL) by adding the notes in .git/NOTES_MERGE_WORKTREE. The notes ref stored in the .git/NOTES_MERGE_REF symref is updated to the resulting commit."),
                    new GitCommandOption("--dry-run", @"--dry-run", @"Do not remove anything; just report the object names whose notes would be removed."),
                    new GitCommandOption("-F", @"-F <file>",
                        @"Take the note message from the given file. Use - to read the note message from the standard input. Lines starting with # and empty lines other than a single line between paragraphs will be stripped out."),
                    new GitCommandOption("-f", @"-f", @"When adding notes to an object that already has notes, overwrite the existing notes (instead of aborting)."),
                    new GitCommandOption("--file", @"--file=<file>",
                        @"Take the note message from the given file. Use - to read the note message from the standard input. Lines starting with # and empty lines other than a single line between paragraphs will be stripped out."),
                    new GitCommandOption("--force", @"--force", @"When adding notes to an object that already has notes, overwrite the existing notes (instead of aborting)."),
                    new GitCommandOption("--ignore-missing", @"--ignore-missing",
                        @"Do not consider it an error to request removing notes from an object that does not have notes attached to it."),
                    new GitCommandOption("-m", @"-m <msg>",
                        @"Use the given note message (instead of prompting). If multiple -m options are given, their values are concatenated as separate paragraphs. Lines starting with # and empty lines other than a single line between paragraphs will be stripped out."),
                    new GitCommandOption("--message", @"--message=<msg>",
                        @"Use the given note message (instead of prompting). If multiple -m options are given, their values are concatenated as separate paragraphs. Lines starting with # and empty lines other than a single line between paragraphs will be stripped out."),
                    new GitCommandOption("-n", @"-n", @"Do not remove anything; just report the object names whose notes would be removed."),
                    new GitCommandOption("-q", @"-q", @"When merging notes, operate quietly."), new GitCommandOption("--quiet", @"--quiet", @"When merging notes, operate quietly."),
                    new GitCommandOption("--reedit-message", @"--reedit-message=<object>",
                        @"Like -C, but with -c the editor is invoked, so that the user can further edit the note message."),
                    new GitCommandOption("--ref", @"--ref <ref>",
                        @"Manipulate the notes tree in <ref>. This overrides GIT_NOTES_REF and the ""core.notesRef"" configuration. The ref specifies the full refname when it begins with refs/notes/; when it begins with notes/, refs/ and otherwise refs/notes/ is prefixed to form a full name of the ref."),
                    new GitCommandOption("--reuse-message", @"--reuse-message=<object>",
                        @"Take the given blob object (for example, another note) as the note message. (Use git notes copy <object> instead to copy notes between objects.)"),
                    new GitCommandOption("-s", @"-s <strategy>",
                        @"When merging notes, resolve notes conflicts using the given strategy. The following strategies are recognized: ""manual"" (default), ""ours"", ""theirs"", ""union"" and ""cat_sort_uniq"". This option overrides the ""notes.mergeStrategy"" configuration setting. See the ""NOTES MERGE STRATEGIES"" section below for more information on each notes merge strategy."),
                    new GitCommandOption("--stdin", @"--stdin",
                        @"Also read the object names to remove notes from from the standard input (there is no reason you cannot combine this with object names from the command line)."),
                    new GitCommandOption("--strategy", @"--strategy=<strategy>",
                        @"When merging notes, resolve notes conflicts using the given strategy. The following strategies are recognized: ""manual"" (default), ""ours"", ""theirs"", ""union"" and ""cat_sort_uniq"". This option overrides the ""notes.mergeStrategy"" configuration setting. See the ""NOTES MERGE STRATEGIES"" section below for more information on each notes merge strategy."),
                    new GitCommandOption("-v", @"-v", @"When merging notes, be more verbose. When pruning notes, report all object names whose notes are removed."),
                    new GitCommandOption("--verbose", @"--verbose", @"When merging notes, be more verbose. When pruning notes, report all object names whose notes are removed.")
                },
                "prune" => new[]
                {
                    new GitCommandOption("--", @"--", @"Do not interpret any more arguments as options."),
                    new GitCommandOption("--dry-run", @"--dry-run", @"Do not remove anything; just report what it would remove."),
                    new GitCommandOption("--expire", @"--expire <time>", @"Only expire loose objects older than <time>."),
                    new GitCommandOption("-n", @"-n", @"Do not remove anything; just report what it would remove."), new GitCommandOption("-v", @"-v", @"Report all removed objects."),
                    new GitCommandOption("--verbose", @"--verbose", @"Report all removed objects.")
                },
                "pull" => new[]
                {
                    new GitCommandOption("--[no-]recurse-submodules[=yes|on-demand|no]", @"--[no-]recurse-submodules[=yes|on-demand|no]",
                        @"This option controls if new commits of all populated submodules should be fetched too (see git-config[1] and gitmodules[5]). That might be necessary to get the data needed for merging submodule commits, a feature Git learned in 1.7.3. Notice that the result of a merge will not be checked out in the submodule, ""git submodule update"" has to be called afterwards to bring the work tree up to date with the merge result."),
                    new GitCommandOption("-4", @"-4", @"Use IPv4 addresses only, ignoring IPv6 addresses."),
                    new GitCommandOption("-6", @"-6", @"Use IPv6 addresses only, ignoring IPv4 addresses."),
                    new GitCommandOption("-a", @"-a",
                        @"Append ref names and object names of fetched refs to the existing contents of .git/FETCH_HEAD. Without this option old data in .git/FETCH_HEAD will be overwritten."),
                    new GitCommandOption("--all", @"--all", @"Fetch all remotes."),
                    new GitCommandOption("--allow-unrelated-histories", @"--allow-unrelated-histories",
                        @"By default, git merge command refuses to merge histories that do not share a common ancestor. This option can be used to override this safety when merging histories of two projects that started their lives independently. As that is a very rare occasion, no configuration variable to enable this by default exists and will not be added."),
                    new GitCommandOption("--append", @"--append",
                        @"Append ref names and object names of fetched refs to the existing contents of .git/FETCH_HEAD. Without this option old data in .git/FETCH_HEAD will be overwritten."),
                    new GitCommandOption("--autostash", @"--autostash",
                        @"Before starting rebase, stash local modifications away (see git-stash[1]) if needed, and apply the stash when done. --no-autostash is useful to override the rebase.autoStash configuration variable (see git-config[1]).
This option is only valid when ""--rebase"" is used."),
                    new GitCommandOption("--commit", @"--commit", @"Perform the merge and commit the result. This option can be used to override --no-commit.
With --no-commit perform the merge but pretend the merge failed and do not autocommit, to give the user a chance to inspect and further tweak the merge result before committing."),
                    new GitCommandOption("--deepen", @"--deepen=<depth>",
                        @"Similar to --depth, except it specifies the number of commits from the current shallow boundary instead of from the tip of each remote branch history."),
                    new GitCommandOption("--depth", @"--depth=<depth>",
                        @"Limit fetching to the specified number of commits from the tip of each remote branch history. If fetching to a shallow repository created by git clone with --depth=<depth> option (see git-clone[1]), deepen or shorten the history to the specified number of commits. Tags for the deepened commits are not fetched."),
                    new GitCommandOption("-e", @"-e",
                        @"Invoke an editor before committing successful mechanical merge to further edit the auto-generated merge message, so that the user can explain and justify the merge. The --no-edit option can be used to accept the auto-generated message (this is generally discouraged).
Older scripts may depend on the historical behaviour of not allowing the user to edit the merge log message. They will see an editor opened when they run git merge. To make it easier to adjust such scripts to the updated behaviour, the environment variable GIT_MERGE_AUTOEDIT can be set to no at the beginning of them."),
                    new GitCommandOption("--edit", @"--edit",
                        @"Invoke an editor before committing successful mechanical merge to further edit the auto-generated merge message, so that the user can explain and justify the merge. The --no-edit option can be used to accept the auto-generated message (this is generally discouraged).
Older scripts may depend on the historical behaviour of not allowing the user to edit the merge log message. They will see an editor opened when they run git merge. To make it easier to adjust such scripts to the updated behaviour, the environment variable GIT_MERGE_AUTOEDIT can be set to no at the beginning of them."),
                    new GitCommandOption("-f", @"-f",
                        @"When git fetch is used with <rbranch>:<lbranch> refspec, it refuses to update the local branch <lbranch> unless the remote branch <rbranch> it fetches is a descendant of <lbranch>. This option overrides that check."),
                    new GitCommandOption("--ff", @"--ff",
                        @"When the merge resolves as a fast-forward, only update the branch pointer, without creating a merge commit. This is the default behavior."),
                    new GitCommandOption("--ff-only", @"--ff-only",
                        @"Refuse to merge and exit with a non-zero status unless the current HEAD is already up-to-date or the merge can be resolved as a fast-forward."),
                    new GitCommandOption("--force", @"--force",
                        @"When git fetch is used with <rbranch>:<lbranch> refspec, it refuses to update the local branch <lbranch> unless the remote branch <rbranch> it fetches is a descendant of <lbranch>. This option overrides that check."),
                    new GitCommandOption("--ipv4", @"--ipv4", @"Use IPv4 addresses only, ignoring IPv6 addresses."),
                    new GitCommandOption("--ipv6", @"--ipv6", @"Use IPv6 addresses only, ignoring IPv4 addresses."), new GitCommandOption("-k", @"-k", @"Keep downloaded pack."),
                    new GitCommandOption("--keep", @"--keep", @"Keep downloaded pack."), new GitCommandOption("--log", @"--log[=<n>]",
                        @"In addition to branch names, populate the log message with one-line descriptions from at most <n> actual commits that are being merged. See also git-fmt-merge-msg[1].
With --no-log do not list one-line descriptions from the actual commits being merged."),
                    new GitCommandOption("-n", @"-n", @"Show a diffstat at the end of the merge. The diffstat is also controlled by the configuration option merge.stat.
With -n or --no-stat do not show a diffstat at the end of the merge."),
                    new GitCommandOption("--no-autostash", @"--no-autostash",
                        @"Before starting rebase, stash local modifications away (see git-stash[1]) if needed, and apply the stash when done. --no-autostash is useful to override the rebase.autoStash configuration variable (see git-config[1]).
This option is only valid when ""--rebase"" is used."),
                    new GitCommandOption("--no-commit", @"--no-commit",
                        @"Perform the merge and commit the result. This option can be used to override --no-commit.
With --no-commit perform the merge but pretend the merge failed and do not autocommit, to give the user a chance to inspect and further tweak the merge result before committing."),
                    new GitCommandOption("--no-edit", @"--no-edit",
                        @"Invoke an editor before committing successful mechanical merge to further edit the auto-generated merge message, so that the user can explain and justify the merge. The --no-edit option can be used to accept the auto-generated message (this is generally discouraged).
Older scripts may depend on the historical behaviour of not allowing the user to edit the merge log message. They will see an editor opened when they run git merge. To make it easier to adjust such scripts to the updated behaviour, the environment variable GIT_MERGE_AUTOEDIT can be set to no at the beginning of them."),
                    new GitCommandOption("--no-ff", @"--no-ff",
                        @"Create a merge commit even when the merge resolves as a fast-forward. This is the default behaviour when merging an annotated (and possibly signed) tag."),
                    new GitCommandOption("--no-log", @"--no-log",
                        @"In addition to branch names, populate the log message with one-line descriptions from at most <n> actual commits that are being merged. See also git-fmt-merge-msg[1].
With --no-log do not list one-line descriptions from the actual commits being merged."),
                    new GitCommandOption("--no-rebase", @"--no-rebase", @"Override earlier --rebase."),
                    new GitCommandOption("--no-squash", @"--no-squash",
                        @"Produce the working tree and index state as if a real merge happened (except for the merge information), but do not actually make a commit, move the HEAD, or record $GIT_DIR/MERGE_HEAD (to cause the next git commit command to create a merge commit). This allows you to create a single commit on top of the current branch whose effect is the same as merging another branch (or more in case of an octopus).
With --no-squash perform the merge and commit the result. This option can be used to override --squash."),
                    new GitCommandOption("--no-stat", @"--no-stat", @"Show a diffstat at the end of the merge. The diffstat is also controlled by the configuration option merge.stat.
With -n or --no-stat do not show a diffstat at the end of the merge."),
                    new GitCommandOption("--no-summary", @"--no-summary", @"Synonyms to --stat and --no-stat; these are deprecated and will be removed in the future."),
                    new GitCommandOption("--no-tags", @"--no-tags",
                        @"By default, tags that point at objects that are downloaded from the remote repository are fetched and stored locally. This option disables this automatic tag following. The default behavior for a remote may be specified with the remote.<name>.tagOpt setting. See git-config[1]."),
                    new GitCommandOption("--no-verify-signatures", @"--no-verify-signatures",
                        @"Verify that the tip commit of the side branch being merged is signed with a valid key, i.e. a key that has a valid uid: in the default trust model, this means the signing key has been signed by a trusted key. If the tip commit of the side branch is not signed with a valid key, the merge is aborted."),
                    new GitCommandOption("--progress", @"--progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal, unless -q is specified. This flag forces progress status even if the standard error stream is not directed to a terminal."),
                    new GitCommandOption("-q", @"-q",
                        @"This is passed to both underlying git-fetch to squelch reporting of during transfer, and underlying git-merge to squelch output during merging."),
                    new GitCommandOption("--quiet", @"--quiet",
                        @"This is passed to both underlying git-fetch to squelch reporting of during transfer, and underlying git-merge to squelch output during merging."),
                    new GitCommandOption("-r", @"-r",
                        @"When true, rebase the current branch on top of the upstream branch after fetching. If there is a remote-tracking branch corresponding to the upstream branch and the upstream branch was rebased since last fetched, the rebase uses that information to avoid rebasing non-local changes.
When set to preserve, rebase with the --preserve-merges option passed to git rebase so that locally created merge commits will not be flattened.
When false, merge the current branch into the upstream branch.
When interactive, enable the interactive mode of rebase.
See pull.rebase, branch.<name>.rebase and branch.autoSetupRebase in git-config[1] if you want to make git pull always use --rebase instead of merging.
Note
This is a potentially dangerous mode of operation. It rewrites history, which does not bode well when you published that history already. Do not use this option unless you have read git-rebase[1] carefully."),
                    new GitCommandOption("--rebase[=false|true|preserve|interactive]", @"--rebase[=false|true|preserve|interactive]",
                        @"When true, rebase the current branch on top of the upstream branch after fetching. If there is a remote-tracking branch corresponding to the upstream branch and the upstream branch was rebased since last fetched, the rebase uses that information to avoid rebasing non-local changes.
When set to preserve, rebase with the --preserve-merges option passed to git rebase so that locally created merge commits will not be flattened.
When false, merge the current branch into the upstream branch.
When interactive, enable the interactive mode of rebase.
See pull.rebase, branch.<name>.rebase and branch.autoSetupRebase in git-config[1] if you want to make git pull always use --rebase instead of merging.
Note
This is a potentially dangerous mode of operation. It rewrites history, which does not bode well when you published that history already. Do not use this option unless you have read git-rebase[1] carefully."),
                    new GitCommandOption("-s", @"-s <strategy>",
                        @"Use the given merge strategy; can be supplied more than once to specify them in the order they should be tried. If there is no -s option, a built-in list of strategies is used instead (git merge-recursive when merging a single head, git merge-octopus otherwise)."),
                    new GitCommandOption("--shallow-exclude", @"--shallow-exclude=<revision>",
                        @"Deepen or shorten the history of a shallow repository to exclude commits reachable from a specified remote branch or tag. This option can be specified multiple times."),
                    new GitCommandOption("--shallow-since", @"--shallow-since=<date>",
                        @"Deepen or shorten the history of a shallow repository to include all reachable commits after <date>."),
                    new GitCommandOption("--squash", @"--squash",
                        @"Produce the working tree and index state as if a real merge happened (except for the merge information), but do not actually make a commit, move the HEAD, or record $GIT_DIR/MERGE_HEAD (to cause the next git commit command to create a merge commit). This allows you to create a single commit on top of the current branch whose effect is the same as merging another branch (or more in case of an octopus).
With --no-squash perform the merge and commit the result. This option can be used to override --squash."),
                    new GitCommandOption("--stat", @"--stat", @"Show a diffstat at the end of the merge. The diffstat is also controlled by the configuration option merge.stat.
With -n or --no-stat do not show a diffstat at the end of the merge."),
                    new GitCommandOption("--strategy", @"--strategy=<strategy>",
                        @"Use the given merge strategy; can be supplied more than once to specify them in the order they should be tried. If there is no -s option, a built-in list of strategies is used instead (git merge-recursive when merging a single head, git merge-octopus otherwise)."),
                    new GitCommandOption("--strategy-option", @"--strategy-option=<option>", @"Pass merge strategy specific option through to the merge strategy."),
                    new GitCommandOption("--summary", @"--summary", @"Synonyms to --stat and --no-stat; these are deprecated and will be removed in the future."),
                    new GitCommandOption("-u", @"-u",
                        @"By default git fetch refuses to update the head which corresponds to the current branch. This flag disables the check. This is purely for the internal use for git pull to communicate with git fetch, and unless you are implementing your own Porcelain you are not supposed to use it."),
                    new GitCommandOption("--unshallow", @"--unshallow",
                        @"If the source repository is complete, convert a shallow repository to a complete one, removing all the limitations imposed by shallow repositories.
If the source repository is shallow, fetch as much as possible so that the current repository has the same history as the source repository."),
                    new GitCommandOption("--update-head-ok", @"--update-head-ok",
                        @"By default git fetch refuses to update the head which corresponds to the current branch. This flag disables the check. This is purely for the internal use for git pull to communicate with git fetch, and unless you are implementing your own Porcelain you are not supposed to use it."),
                    new GitCommandOption("--update-shallow", @"--update-shallow",
                        @"By default when fetching from a shallow repository, git fetch refuses refs that require updating .git/shallow. This option updates .git/shallow and accept such refs."),
                    new GitCommandOption("--upload-pack", @"--upload-pack <upload-pack>",
                        @"When given, and the repository to fetch from is handled by git fetch-pack, --exec=<upload-pack> is passed to the command to specify non-default path for the command run on the other end."),
                    new GitCommandOption("-v", @"-v", @"Pass --verbose to git-fetch and git-merge."),
                    new GitCommandOption("--verbose", @"--verbose", @"Pass --verbose to git-fetch and git-merge."),
                    new GitCommandOption("--verify-signatures", @"--verify-signatures",
                        @"Verify that the tip commit of the side branch being merged is signed with a valid key, i.e. a key that has a valid uid: in the default trust model, this means the signing key has been signed by a trusted key. If the tip commit of the side branch is not signed with a valid key, the merge is aborted."),
                    new GitCommandOption("-X", @"-X <option>", @"Pass merge strategy specific option through to the merge strategy.")
                },
                "push" => new[]
                {
                    new GitCommandOption("--[no-]atomic", @"--[no-]atomic",
                        @"Use an atomic transaction on the remote side if available. Either all refs are updated, or on error, no refs are updated. If the server does not support atomic pushes the push will fail."),
                    new GitCommandOption("--[no-]force-with-lease", @"--[no-]force-with-lease",
                        @"Usually, ""git push"" refuses to update a remote ref that is not an ancestor of the local ref used to overwrite it.
This option overrides this restriction if the current value of the remote ref is the expected value. ""git push"" fails otherwise.
Imagine that you have to rebase what you have already published. You will have to bypass the ""must fast-forward"" rule in order to replace the history you originally published with the rebased history. If somebody else built on top of your original history while you are rebasing, the tip of the branch at the remote may advance with her commit, and blindly pushing with --force will lose her work.
This option allows you to say that you expect the history you are updating is what you rebased and want to replace. If the remote ref still points at the commit you specified, you can be sure that no other people did anything to the ref. It is like taking a ""lease"" on the ref without explicitly locking it, and the remote ref is updated only if the ""lease"" is still valid.
--force-with-lease alone, without specifying the details, will protect all remote refs that are going to be updated by requiring their current value to be the same as the remote-tracking branch we have for them.
--force-with-lease=<refname>, without specifying the expected value, will protect the named ref (alone), if it is going to be updated, by requiring its current value to be the same as the remote-tracking branch we have for it.
--force-with-lease=<refname>:<expect> will protect the named ref (alone), if it is going to be updated, by requiring its current value to be the same as the specified value <expect> (which is allowed to be different from the remote-tracking branch we have for the refname, or we do not even have to have such a remote-tracking branch when this form is used). If <expect> is the empty string, then the named ref must not already exist.
Note that all forms other than --force-with-lease=<refname>:<expect> that specifies the expected current value of the ref explicitly are still experimental and their semantics may change as we gain experience with this feature.
""--no-force-with-lease"" will cancel all the previous --force-with-lease on the command line."),
                    new GitCommandOption("--[no-]signed", @"--[no-]signed",
                        @"GPG-sign the push request to update refs on the receiving side, to allow it to be checked by the hooks and/or be logged. If false or --no-signed, no signing will be attempted. If true or --signed, the push will fail if the server does not support signed pushes. If set to if-asked, sign if and only if the server supports signed pushes. The push will also fail if the actual call to gpg --sign fails. See git-receive-pack[1] for the details on the receiving end."),
                    new GitCommandOption("--[no-]thin", @"--[no-]thin",
                        @"These options are passed to git-send-pack[1]. A thin transfer significantly reduces the amount of sent data when the sender and receiver share many of the same objects in common. The default is \\--thin."),
                    new GitCommandOption("--[no-]verify", @"--[no-]verify",
                        @"Toggle the pre-push hook (see githooks[5]). The default is --verify, giving the hook a chance to prevent the push. With --no-verify, the hook is bypassed completely."),
                    new GitCommandOption("-4", @"-4", @"Use IPv4 addresses only, ignoring IPv6 addresses."),
                    new GitCommandOption("-6", @"-6", @"Use IPv6 addresses only, ignoring IPv4 addresses."),
                    new GitCommandOption("--all", @"--all", @"Push all branches (i.e. refs under refs/heads/); cannot be used with other <refspec>."),
                    new GitCommandOption("--delete", @"--delete", @"All listed refs are deleted from the remote repository. This is the same as prefixing all refs with a colon."),
                    new GitCommandOption("--dry-run", @"--dry-run", @"Do everything except actually send the updates."),
                    new GitCommandOption("--exec", @"--exec=<git-receive-pack>",
                        @"Path to the git-receive-pack program on the remote end. Sometimes useful when pushing to a remote repository over ssh, and you do not have the program in a directory on the default $PATH."),
                    new GitCommandOption("-f", @"-f",
                        @"Usually, the command refuses to update a remote ref that is not an ancestor of the local ref used to overwrite it. Also, when --force-with-lease option is used, the command refuses to update a remote ref whose current value does not match what is expected.
This flag disables these checks, and can cause the remote repository to lose commits; use it with care.
Note that --force applies to all the refs that are pushed, hence using it with push.default set to matching or with multiple push destinations configured with remote.*.push may overwrite refs other than the current branch (including local refs that are strictly behind their remote counterpart). To force a push to only one branch, use a + in front of the refspec to push (e.g git push origin +master to force a push to the master branch). See the <refspec>... section above for details."),
                    new GitCommandOption("--follow-tags", @"--follow-tags",
                        @"Push all the refs that would be pushed without this option, and also push annotated tags in refs/tags that are missing from the remote but are pointing at commit-ish that are reachable from the refs being pushed. This can also be specified with configuration variable push.followTags. For more information, see push.followTags in git-config[1]."),
                    new GitCommandOption("--force", @"--force",
                        @"Usually, the command refuses to update a remote ref that is not an ancestor of the local ref used to overwrite it. Also, when --force-with-lease option is used, the command refuses to update a remote ref whose current value does not match what is expected.
This flag disables these checks, and can cause the remote repository to lose commits; use it with care.
Note that --force applies to all the refs that are pushed, hence using it with push.default set to matching or with multiple push destinations configured with remote.*.push may overwrite refs other than the current branch (including local refs that are strictly behind their remote counterpart). To force a push to only one branch, use a + in front of the refspec to push (e.g git push origin +master to force a push to the master branch). See the <refspec>... section above for details."),
                    new GitCommandOption("--force-with-lease", @"--force-with-lease=<refname>",
                        @"Usually, ""git push"" refuses to update a remote ref that is not an ancestor of the local ref used to overwrite it.
This option overrides this restriction if the current value of the remote ref is the expected value. ""git push"" fails otherwise.
Imagine that you have to rebase what you have already published. You will have to bypass the ""must fast-forward"" rule in order to replace the history you originally published with the rebased history. If somebody else built on top of your original history while you are rebasing, the tip of the branch at the remote may advance with her commit, and blindly pushing with --force will lose her work.
This option allows you to say that you expect the history you are updating is what you rebased and want to replace. If the remote ref still points at the commit you specified, you can be sure that no other people did anything to the ref. It is like taking a ""lease"" on the ref without explicitly locking it, and the remote ref is updated only if the ""lease"" is still valid.
--force-with-lease alone, without specifying the details, will protect all remote refs that are going to be updated by requiring their current value to be the same as the remote-tracking branch we have for them.
--force-with-lease=<refname>, without specifying the expected value, will protect the named ref (alone), if it is going to be updated, by requiring its current value to be the same as the remote-tracking branch we have for it.
--force-with-lease=<refname>:<expect> will protect the named ref (alone), if it is going to be updated, by requiring its current value to be the same as the specified value <expect> (which is allowed to be different from the remote-tracking branch we have for the refname, or we do not even have to have such a remote-tracking branch when this form is used). If <expect> is the empty string, then the named ref must not already exist.
Note that all forms other than --force-with-lease=<refname>:<expect> that specifies the expected current value of the ref explicitly are still experimental and their semantics may change as we gain experience with this feature.
""--no-force-with-lease"" will cancel all the previous --force-with-lease on the command line."),
                    new GitCommandOption("--force-with-lease:<expect>", @"--force-with-lease=<refname>:<expect>",
                        @"Usually, ""git push"" refuses to update a remote ref that is not an ancestor of the local ref used to overwrite it.
This option overrides this restriction if the current value of the remote ref is the expected value. ""git push"" fails otherwise.
Imagine that you have to rebase what you have already published. You will have to bypass the ""must fast-forward"" rule in order to replace the history you originally published with the rebased history. If somebody else built on top of your original history while you are rebasing, the tip of the branch at the remote may advance with her commit, and blindly pushing with --force will lose her work.
This option allows you to say that you expect the history you are updating is what you rebased and want to replace. If the remote ref still points at the commit you specified, you can be sure that no other people did anything to the ref. It is like taking a ""lease"" on the ref without explicitly locking it, and the remote ref is updated only if the ""lease"" is still valid.
--force-with-lease alone, without specifying the details, will protect all remote refs that are going to be updated by requiring their current value to be the same as the remote-tracking branch we have for them.
--force-with-lease=<refname>, without specifying the expected value, will protect the named ref (alone), if it is going to be updated, by requiring its current value to be the same as the remote-tracking branch we have for it.
--force-with-lease=<refname>:<expect> will protect the named ref (alone), if it is going to be updated, by requiring its current value to be the same as the specified value <expect> (which is allowed to be different from the remote-tracking branch we have for the refname, or we do not even have to have such a remote-tracking branch when this form is used). If <expect> is the empty string, then the named ref must not already exist.
Note that all forms other than --force-with-lease=<refname>:<expect> that specifies the expected current value of the ref explicitly are still experimental and their semantics may change as we gain experience with this feature.
""--no-force-with-lease"" will cancel all the previous --force-with-lease on the command line."),
                    new GitCommandOption("--ipv4", @"--ipv4", @"Use IPv4 addresses only, ignoring IPv6 addresses."),
                    new GitCommandOption("--ipv6", @"--ipv6", @"Use IPv6 addresses only, ignoring IPv4 addresses."),
                    new GitCommandOption("--mirror", @"--mirror",
                        @"Instead of naming each ref to push, specifies that all refs under refs/ (which includes but is not limited to refs/heads/, refs/remotes/, and refs/tags/) be mirrored to the remote repository. Newly created local refs will be pushed to the remote end, locally updated refs will be force updated on the remote end, and deleted refs will be removed from the remote end. This is the default if the configuration option remote.<remote>.mirror is set."),
                    new GitCommandOption("-n", @"-n", @"Do everything except actually send the updates."),
                    new GitCommandOption("--no-recurse-submodules", @"--no-recurse-submodules",
                        @"May be used to make sure all submodule commits used by the revisions to be pushed are available on a remote-tracking branch. If check is used Git will verify that all submodule commits that changed in the revisions to be pushed are available on at least one remote of the submodule. If any commits are missing the push will be aborted and exit with non-zero status. If on-demand is used all submodules that changed in the revisions to be pushed will be pushed. If on-demand was not able to push all necessary revisions it will also be aborted and exit with non-zero status. A value of no or using --no-recurse-submodules can be used to override the push.recurseSubmodules configuration variable when no submodule recursion is required."),
                    new GitCommandOption("-o", @"-o",
                        @"Transmit the given string to the server, which passes them to the pre-receive as well as the post-receive hook. The given string must not contain a NUL or LF character."),
                    new GitCommandOption("--porcelain", @"--porcelain",
                        @"Produce machine-readable output. The output status line for each ref will be tab-separated and sent to stdout instead of stderr. The full symbolic names of the refs will be given."),
                    new GitCommandOption("--progress", @"--progress",
                        @"Progress status is reported on the standard error stream by default when it is attached to a terminal, unless -q is specified. This flag forces progress status even if the standard error stream is not directed to a terminal."),
                    new GitCommandOption("--prune", @"--prune",
                        @"Remove remote branches that don''t have a local counterpart. For example a remote branch tmp will be removed if a local branch with the same name doesn''t exist any more. This also respects refspecs, e.g. git push --prune remote refs/heads/*:refs/tmp/* would make sure that remote refs/tmp/foo will be removed if refs/heads/foo doesn''t exist."),
                    new GitCommandOption("--push-option", @"--push-option",
                        @"Transmit the given string to the server, which passes them to the pre-receive as well as the post-receive hook. The given string must not contain a NUL or LF character."),
                    new GitCommandOption("-q", @"-q",
                        @"Suppress all output, including the listing of updated refs, unless an error occurs. Progress is not reported to the standard error stream."),
                    new GitCommandOption("--quiet", @"--quiet",
                        @"Suppress all output, including the listing of updated refs, unless an error occurs. Progress is not reported to the standard error stream."),
                    new GitCommandOption("--receive-pack", @"--receive-pack=<git-receive-pack>",
                        @"Path to the git-receive-pack program on the remote end. Sometimes useful when pushing to a remote repository over ssh, and you do not have the program in a directory on the default $PATH."),
                    new GitCommandOption("--recurse-submodules=check|on-demand|no", @"--recurse-submodules=check|on-demand|no",
                        @"May be used to make sure all submodule commits used by the revisions to be pushed are available on a remote-tracking branch. If check is used Git will verify that all submodule commits that changed in the revisions to be pushed are available on at least one remote of the submodule. If any commits are missing the push will be aborted and exit with non-zero status. If on-demand is used all submodules that changed in the revisions to be pushed will be pushed. If on-demand was not able to push all necessary revisions it will also be aborted and exit with non-zero status. A value of no or using --no-recurse-submodules can be used to override the push.recurseSubmodules configuration variable when no submodule recursion is required."),
                    new GitCommandOption("--repo", @"--repo=<repository>",
                        @"This option is equivalent to the <repository> argument. If both are specified, the command-line argument takes precedence."),
                    new GitCommandOption("--set-upstream", @"--set-upstream",
                        @"For every branch that is up to date or successfully pushed, add upstream (tracking) reference, used by argument-less git-pull[1] and other commands. For more information, see branch.<name>.merge in git-config[1]."),
                    new GitCommandOption("--sign=(true|false|if-asked)", @"--sign=(true|false|if-asked)",
                        @"GPG-sign the push request to update refs on the receiving side, to allow it to be checked by the hooks and/or be logged. If false or --no-signed, no signing will be attempted. If true or --signed, the push will fail if the server does not support signed pushes. If set to if-asked, sign if and only if the server supports signed pushes. The push will also fail if the actual call to gpg --sign fails. See git-receive-pack[1] for the details on the receiving end."),
                    new GitCommandOption("--tags", @"--tags", @"All refs under refs/tags are pushed, in addition to refspecs explicitly listed on the command line."),
                    new GitCommandOption("-u", @"-u",
                        @"For every branch that is up to date or successfully pushed, add upstream (tracking) reference, used by argument-less git-pull[1] and other commands. For more information, see branch.<name>.merge in git-config[1]."),
                    new GitCommandOption("-v", @"-v", @"Run verbosely."), new GitCommandOption("--verbose", @"--verbose", @"Run verbosely.")
                },
                "rebase" => new[]
                {
                    new GitCommandOption("--abort", @"--abort",
                        @"Abort the rebase operation and reset HEAD to the original branch. If <branch> was provided when the rebase operation was started, then HEAD will be reset to <branch>. Otherwise HEAD will be reset to where it was when the rebase operation was started."),
                    new GitCommandOption("--autosquash", @"--autosquash",
                        @"When the commit log message begins with ""squash! ..."" (or ""fixup! ...""), and there is a commit whose title begins with the same ..., automatically modify the todo list of rebase -i so that the commit marked for squashing comes right after the commit to be modified, and change the action of the moved commit from pick to squash (or fixup). Ignores subsequent ""fixup! "" or ""squash! "" after the first, in case you referred to an earlier fixup/squash with git commit --fixup/--squash.
This option is only valid when the --interactive option is used.
If the --autosquash option is enabled by default using the configuration variable rebase.autoSquash, this option can be used to override and disable this setting."),
                    new GitCommandOption("--autostash", @"--autostash",
                        @"Automatically create a temporary stash before the operation begins, and apply it after the operation ends. This means that you can run rebase on a dirty worktree. However, use with care: the final stash application after a successful rebase might result in non-trivial conflicts."),
                    new GitCommandOption("-C<n>", @"-C<n>",
                        @"Ensure at least <n> lines of surrounding context match before and after each change. When fewer lines of surrounding context exist they all must match. By default no context is ever ignored."),
                    new GitCommandOption("--committer-date-is-author-date", @"--committer-date-is-author-date",
                        @"These flags are passed to git am to easily change the dates of the rebased commits (see git-am[1]). Incompatible with the --interactive option."),
                    new GitCommandOption("--continue", @"--continue", @"Restart the rebasing process after having resolved a merge conflict."),
                    new GitCommandOption("--edit-todo", @"--edit-todo", @"Edit the todo list during an interactive rebase."), new GitCommandOption("--exec", @"--exec <cmd>",
                        @"Append ""exec <cmd>"" after each line creating a commit in the final history. <cmd> will be interpreted as one or more shell commands.
You may execute several commands by either using one instance of --exec with several commands:
git rebase -i --exec ""cmd1 && cmd2 && ...""
or by giving more than one --exec:
git rebase -i --exec ""cmd1"" --exec ""cmd2"" --exec ...
If --autosquash is used, ""exec"" lines will not be appended for the intermediate commits, and will only appear at the end of each squash/fixup series.
This uses the --interactive machinery internally, but it can be run without an explicit --interactive."),
                    new GitCommandOption("-f", @"-f", @"Force a rebase even if the current branch is up-to-date and the command without --force would return without doing anything.
You may find this (or --no-ff with an interactive rebase) helpful after reverting a topic branch merge, as this option recreates the topic branch with fresh commits so it can be remerged successfully without needing to ""revert the reversion"" (see the revert-a-faulty-merge How-To for details)."),
                    new GitCommandOption("--force-rebase", @"--force-rebase",
                        @"Force a rebase even if the current branch is up-to-date and the command without --force would return without doing anything.
You may find this (or --no-ff with an interactive rebase) helpful after reverting a topic branch merge, as this option recreates the topic branch with fresh commits so it can be remerged successfully without needing to ""revert the reversion"" (see the revert-a-faulty-merge How-To for details)."),
                    new GitCommandOption("--fork-point", @"--fork-point",
                        @"Use reflog to find a better common ancestor between <upstream> and <branch> when calculating which commits have been introduced by <branch>.
When --fork-point is active, fork_point will be used instead of <upstream> to calculate the set of commits to rebase, where fork_point is the result of git merge-base --fork-point <upstream> <branch> command (see git-merge-base[1]). If fork_point ends up being empty, the <upstream> will be used as a fallback.
If either <upstream> or --root is given on the command line, then the default is --no-fork-point, otherwise the default is --fork-point."),
                    new GitCommandOption("--gpg-sign", @"--gpg-sign[=<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("-i", @"-i",
                        @"Make a list of the commits which are about to be rebased. Let the user edit that list before rebasing. This mode can also be used to split commits (see SPLITTING COMMITS below).
The commit list format can be changed by setting the configuration option rebase.instructionFormat. A customized instruction format will automatically have the long commit hash prepended to the format."),
                    new GitCommandOption("--ignore-date", @"--ignore-date",
                        @"These flags are passed to git am to easily change the dates of the rebased commits (see git-am[1]). Incompatible with the --interactive option."),
                    new GitCommandOption("--ignore-whitespace", @"--ignore-whitespace",
                        @"These flag are passed to the git apply program (see git-apply[1]) that applies the patch. Incompatible with the --interactive option."),
                    new GitCommandOption("--interactive", @"--interactive",
                        @"Make a list of the commits which are about to be rebased. Let the user edit that list before rebasing. This mode can also be used to split commits (see SPLITTING COMMITS below).
The commit list format can be changed by setting the configuration option rebase.instructionFormat. A customized instruction format will automatically have the long commit hash prepended to the format."),
                    new GitCommandOption("--keep-empty", @"--keep-empty", @"Keep the commits that do not change anything from its parents in the result."), new GitCommandOption("-m", @"-m",
                        @"Use merging strategies to rebase. When the recursive (default) merge strategy is used, this allows rebase to be aware of renames on the upstream side.
Note that a rebase merge works by replaying each commit from the working branch on top of the <upstream> branch. Because of this, when a merge conflict happens, the side reported as ours is the so-far rebased series, starting with <upstream>, and theirs is the working branch. In other words, the sides are swapped."),
                    new GitCommandOption("--merge", @"--merge",
                        @"Use merging strategies to rebase. When the recursive (default) merge strategy is used, this allows rebase to be aware of renames on the upstream side.
Note that a rebase merge works by replaying each commit from the working branch on top of the <upstream> branch. Because of this, when a merge conflict happens, the side reported as ours is the so-far rebased series, starting with <upstream>, and theirs is the working branch. In other words, the sides are swapped."),
                    new GitCommandOption("-n", @"-n", @"Do not show a diffstat as part of the rebase process."), new GitCommandOption("--no-autosquash", @"--no-autosquash",
                        @"When the commit log message begins with ""squash! ..."" (or ""fixup! ...""), and there is a commit whose title begins with the same ..., automatically modify the todo list of rebase -i so that the commit marked for squashing comes right after the commit to be modified, and change the action of the moved commit from pick to squash (or fixup). Ignores subsequent ""fixup! "" or ""squash! "" after the first, in case you referred to an earlier fixup/squash with git commit --fixup/--squash.
This option is only valid when the --interactive option is used.
If the --autosquash option is enabled by default using the configuration variable rebase.autoSquash, this option can be used to override and disable this setting."),
                    new GitCommandOption("--no-autostash", @"--no-autostash",
                        @"Automatically create a temporary stash before the operation begins, and apply it after the operation ends. This means that you can run rebase on a dirty worktree. However, use with care: the final stash application after a successful rebase might result in non-trivial conflicts."),
                    new GitCommandOption("--no-ff", @"--no-ff",
                        @"With --interactive, cherry-pick all rebased commits instead of fast-forwarding over the unchanged ones. This ensures that the entire history of the rebased branch is composed of new commits.
Without --interactive, this is a synonym for --force-rebase.
You may find this helpful after reverting a topic branch merge, as this option recreates the topic branch with fresh commits so it can be remerged successfully without needing to ""revert the reversion"" (see the revert-a-faulty-merge How-To for details)."),
                    new GitCommandOption("--no-fork-point", @"--no-fork-point",
                        @"Use reflog to find a better common ancestor between <upstream> and <branch> when calculating which commits have been introduced by <branch>.
When --fork-point is active, fork_point will be used instead of <upstream> to calculate the set of commits to rebase, where fork_point is the result of git merge-base --fork-point <upstream> <branch> command (see git-merge-base[1]). If fork_point ends up being empty, the <upstream> will be used as a fallback.
If either <upstream> or --root is given on the command line, then the default is --no-fork-point, otherwise the default is --fork-point."),
                    new GitCommandOption("--no-stat", @"--no-stat", @"Do not show a diffstat as part of the rebase process."),
                    new GitCommandOption("--no-verify", @"--no-verify", @"This option bypasses the pre-rebase hook. See also githooks[5]."), new GitCommandOption("--onto",
                        @"--onto <newbase>",
                        @"Starting point at which to create the new commits. If the --onto option is not specified, the starting point is <upstream>. May be any valid commit, and not just an existing branch name.
As a special case, you may use ""A...B"" as a shortcut for the merge base of A and B if there is exactly one merge base. You can leave out at most one of A and B, in which case it defaults to HEAD."),
                    new GitCommandOption("-p", @"-p",
                        @"Recreate merge commits instead of flattening the history by replaying commits a merge commit introduces. Merge conflict resolutions or manual amendments to merge commits are not preserved.
This uses the --interactive machinery internally, but combining it with the --interactive option explicitly is generally not a good idea unless you know what you are doing (see BUGS below)."),
                    new GitCommandOption("--preserve-merges", @"--preserve-merges",
                        @"Recreate merge commits instead of flattening the history by replaying commits a merge commit introduces. Merge conflict resolutions or manual amendments to merge commits are not preserved.
This uses the --interactive machinery internally, but combining it with the --interactive option explicitly is generally not a good idea unless you know what you are doing (see BUGS below)."),
                    new GitCommandOption("-q", @"-q", @"Be quiet. Implies --no-stat."), new GitCommandOption("--quiet", @"--quiet", @"Be quiet. Implies --no-stat."),
                    new GitCommandOption("--root", @"--root",
                        @"Rebase all commits reachable from <branch>, instead of limiting them with an <upstream>. This allows you to rebase the root commit(s) on a branch. When used with --onto, it will skip changes already contained in <newbase> (instead of <upstream>) whereas without --onto it will operate on every change. When used together with both --onto and --preserve-merges, all root commits will be rewritten to have <newbase> as parent instead."),
                    new GitCommandOption("-s", @"-s <strategy>", @"Use the given merge strategy. If there is no -s option git merge-recursive is used instead. This implies --merge.
Because git rebase replays each commit from the working branch on top of the <upstream> branch using the given strategy, using the ours strategy simply discards all patches from the <branch>, which makes little sense."),
                    new GitCommandOption("-S[<keyid>]", @"-S[<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("--skip", @"--skip", @"Restart the rebasing process by skipping the current patch."),
                    new GitCommandOption("--stat", @"--stat",
                        @"Show a diffstat of what changed upstream since the last rebase. The diffstat is also controlled by the configuration option rebase.stat."),
                    new GitCommandOption("--strategy", @"--strategy=<strategy>",
                        @"Use the given merge strategy. If there is no -s option git merge-recursive is used instead. This implies --merge.
Because git rebase replays each commit from the working branch on top of the <upstream> branch using the given strategy, using the ours strategy simply discards all patches from the <branch>, which makes little sense."),
                    new GitCommandOption("--strategy-option", @"--strategy-option=<strategy-option>",
                        @"Pass the <strategy-option> through to the merge strategy. This implies --merge and, if no strategy has been specified, -s recursive. Note the reversal of ours and theirs as noted above for the -m option."),
                    new GitCommandOption("-v", @"-v", @"Be verbose. Implies --stat."), new GitCommandOption("--verbose", @"--verbose", @"Be verbose. Implies --stat."),
                    new GitCommandOption("--verify", @"--verify",
                        @"Allows the pre-rebase hook to run, which is the default. This option can be used to override --no-verify. See also githooks[5]."),
                    new GitCommandOption("--whitespace", @"--whitespace=<option>",
                        @"These flag are passed to the git apply program (see git-apply[1]) that applies the patch. Incompatible with the --interactive option."),
                    new GitCommandOption("-x",
                        @"-x <cmd>", @"Append ""exec <cmd>"" after each line creating a commit in the final history. <cmd> will be interpreted as one or more shell commands.
You may execute several commands by either using one instance of --exec with several commands:
git rebase -i --exec ""cmd1 && cmd2 && ...""
or by giving more than one --exec:
git rebase -i --exec ""cmd1"" --exec ""cmd2"" --exec ...
If --autosquash is used, ""exec"" lines will not be appended for the intermediate commits, and will only appear at the end of each squash/fixup series.
This uses the --interactive machinery internally, but it can be run without an explicit --interactive."),
                    new GitCommandOption("-X", @"-X <strategy-option>",
                        @"Pass the <strategy-option> through to the merge strategy. This implies --merge and, if no strategy has been specified, -s recursive. Note the reversal of ours and theirs as noted above for the -m option.")
                },
                "reflog" => new[]
                {
                    new GitCommandOption("--all", @"--all", @"Process the reflogs of all references."),
                    new GitCommandOption("--dry-run", @"--dry-run", @"Do not actually prune any entries; just show what would have been pruned."),
                    new GitCommandOption("--expire", @"--expire=<time>",
                        @"Prune entries older than the specified time. If this option is not specified, the expiration time is taken from the configuration setting gc.reflogExpire, which in turn defaults to 90 days. --expire=all prunes entries regardless of their age; --expire=never turns off pruning of reachable entries (but see --expire-unreachable)."),
                    new GitCommandOption("--expire-unreachable", @"--expire-unreachable=<time>",
                        @"Prune entries older than <time> that are not reachable from the current tip of the branch. If this option is not specified, the expiration time is taken from the configuration setting gc.reflogExpireUnreachable, which in turn defaults to 30 days. --expire-unreachable=all prunes unreachable entries regardless of their age; --expire-unreachable=never turns off early pruning of unreachable entries (but see --expire)."),
                    new GitCommandOption("-n", @"-n", @"Do not actually prune any entries; just show what would have been pruned."),
                    new GitCommandOption("--rewrite", @"--rewrite",
                        @"If a reflog entry''s predecessor is pruned, adjust its ""old"" SHA-1 to be equal to the ""new"" SHA-1 field of the entry that now precedes it."),
                    new GitCommandOption("--stale-fix", @"--stale-fix",
                        @"Prune any reflog entries that point to ""broken commits"". A broken commit is a commit that is not reachable from any of the reference tips and that refers, directly or indirectly, to a missing commit, tree, or blob object.
This computation involves traversing all the reachable objects, i.e. it has the same cost as git prune. It is primarily intended to fix corruption caused by garbage collecting using older versions of Git, which didn''t protect objects referred to by reflogs."),
                    new GitCommandOption("--updateref", @"--updateref",
                        @"Update the reference to the value of the top reflog entry (i.e. <ref>@{0}) if the previous top entry was pruned. (This option is ignored for symbolic references.)"),
                    new GitCommandOption("--verbose", @"--verbose", @"Print extra information on screen.")
                },
                "remote" => new[]
                {
                    new GitCommandOption("-v", @"-v", @"Be a little more verbose and show remote url after name. NOTE: This must be placed between remote and subcommand."),
                    new GitCommandOption("--verbose", @"--verbose", @"Be a little more verbose and show remote url after name. NOTE: This must be placed between remote and subcommand.")
                },
                "rerere" => System.Array.Empty<GitCommandOption>(),
                "reset" => new[]
                {
                    new GitCommandOption("--hard", @"--hard", @"Resets the index and working tree. Any changes to tracked files in the working tree since <commit> are discarded."),
                    new GitCommandOption("--keep", @"--keep",
                        @"Resets index entries and updates files in the working tree that are different between <commit> and HEAD. If a file that is different between <commit> and HEAD has local changes, reset is aborted."),
                    new GitCommandOption("--merge", @"--merge",
                        @"Resets the index and updates the files in the working tree that are different between <commit> and HEAD, but keeps those which are different between the index and working tree (i.e. which have changes which have not been added). If a file that is different between <commit> and the index has unstaged changes, reset is aborted.
In other words, --merge does something like a git read-tree -u -m <commit>, but carries forward unmerged index entries."),
                    new GitCommandOption("--mixed", @"--mixed",
                        @"Resets the index but not the working tree (i.e., the changed files are preserved but not marked for commit) and reports what has not been updated. This is the default action.
If -N is specified, removed paths are marked as intent-to-add (see git-add[1])."),
                    new GitCommandOption("-q", @"-q", @"Be quiet, only report errors."), new GitCommandOption("--quiet", @"--quiet", @"Be quiet, only report errors."),
                    new GitCommandOption("--soft", @"--soft",
                        @"Does not touch the index file or the working tree at all (but resets the head to <commit>, just like all modes do). This leaves all your changed files ""Changes to be committed"", as git status would put it.")
                },
                "revert" => new[]
                {
                    new GitCommandOption("--abort", @"--abort", @"Cancel the operation and return to the pre-sequence state."),
                    new GitCommandOption("--continue", @"--continue",
                        @"Continue the operation in progress using the information in .git/sequencer. Can be used to continue after resolving conflicts in a failed cherry-pick or revert."),
                    new GitCommandOption("-e", @"-e",
                        @"With this option, git revert will let you edit the commit message prior to committing the revert. This is the default if you run the command from a terminal."),
                    new GitCommandOption("--edit", @"--edit",
                        @"With this option, git revert will let you edit the commit message prior to committing the revert. This is the default if you run the command from a terminal."),
                    new GitCommandOption("--gpg-sign", @"--gpg-sign[=<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("-m parent-number", @"-m parent-number",
                        @"Usually you cannot revert a merge because you do not know which side of the merge should be considered the mainline. This option specifies the parent number (starting from 1) of the mainline and allows revert to reverse the change relative to the specified parent.
Reverting a merge commit declares that you will never want the tree changes brought in by the merge. As a result, later merges will only bring in tree changes introduced by commits that are not ancestors of the previously reverted merge. This may or may not be what you want.
See the revert-a-faulty-merge How-To for more details."),
                    new GitCommandOption("--mainline parent-number", @"--mainline parent-number",
                        @"Usually you cannot revert a merge because you do not know which side of the merge should be considered the mainline. This option specifies the parent number (starting from 1) of the mainline and allows revert to reverse the change relative to the specified parent.
Reverting a merge commit declares that you will never want the tree changes brought in by the merge. As a result, later merges will only bring in tree changes introduced by commits that are not ancestors of the previously reverted merge. This may or may not be what you want.
See the revert-a-faulty-merge How-To for more details."),
                    new GitCommandOption("-n", @"-n",
                        @"Usually the command automatically creates some commits with commit log messages stating which commits were reverted. This flag applies the changes necessary to revert the named commits to your working tree and the index, but does not make the commits. In addition, when this option is used, your index does not have to match the HEAD commit. The revert is done against the beginning state of your index.
This is useful when reverting more than one commits'' effect to your index in a row."),
                    new GitCommandOption("--no-commit", @"--no-commit",
                        @"Usually the command automatically creates some commits with commit log messages stating which commits were reverted. This flag applies the changes necessary to revert the named commits to your working tree and the index, but does not make the commits. In addition, when this option is used, your index does not have to match the HEAD commit. The revert is done against the beginning state of your index.
This is useful when reverting more than one commits'' effect to your index in a row."),
                    new GitCommandOption("--no-edit", @"--no-edit", @"With this option, git revert will not start the commit message editor."),
                    new GitCommandOption("--quit", @"--quit",
                        @"Forget about the current operation in progress. Can be used to clear the sequencer state after a failed cherry-pick or revert."),
                    new GitCommandOption("-s", @"-s", @"Add Signed-off-by line at the end of the commit message. See the signoff option in git-commit[1] for more information."),
                    new GitCommandOption("-S[<keyid>]", @"-S[<keyid>]",
                        @"GPG-sign commits. The keyid argument is optional and defaults to the committer identity; if specified, it must be stuck to the option without a space."),
                    new GitCommandOption("--signoff", @"--signoff",
                        @"Add Signed-off-by line at the end of the commit message. See the signoff option in git-commit[1] for more information."),
                    new GitCommandOption("--strategy", @"--strategy=<strategy>",
                        @"Use the given merge strategy. Should only be used once. See the MERGE STRATEGIES section in git-merge[1] for details."),
                    new GitCommandOption("--strategy-option", @"--strategy-option=<option>",
                        @"Pass the merge strategy-specific option through to the merge strategy. See git-merge[1] for details."),
                    new GitCommandOption("-X<option>", @"-X<option>", @"Pass the merge strategy-specific option through to the merge strategy. See git-merge[1] for details.")
                },
                "rm" => new[]
                {
                    new GitCommandOption("--", @"--",
                        @"This option can be used to separate command-line options from the list of files, (useful when filenames might be mistaken for command-line options)."),
                    new GitCommandOption("--cached", @"--cached",
                        @"Use this option to unstage and remove paths only from the index. Working tree files, whether modified or not, will be left alone."),
                    new GitCommandOption("--dry-run", @"--dry-run",
                        @"Don''t actually remove any file(s). Instead, just show if they exist in the index and would otherwise be removed by the command."),
                    new GitCommandOption("-f", @"-f", @"Override the up-to-date check."), new GitCommandOption("--force", @"--force", @"Override the up-to-date check."),
                    new GitCommandOption("--ignore-unmatch", @"--ignore-unmatch", @"Exit with a zero status even if no files matched."),
                    new GitCommandOption("-n", @"-n",
                        @"Don''t actually remove any file(s). Instead, just show if they exist in the index and would otherwise be removed by the command."),
                    new GitCommandOption("-q", @"-q", @"git rm normally outputs one line (in the form of an rm command) for each file removed. This option suppresses that output."),
                    new GitCommandOption("--quiet", @"--quiet",
                        @"git rm normally outputs one line (in the form of an rm command) for each file removed. This option suppresses that output."),
                    new GitCommandOption("-r", @"-r", @"Allow recursive removal when a leading directory name is given.")
                },
                "shortlog" => new[]
                {
                    new GitCommandOption("[\\--]...", @"[\\--] <path>...", @"Consider only commits that are enough to explain how the files that match the specified paths came to be.
Paths may need to be prefixed with ""-- "" to separate them from options or the revision range, when confusion arises."),
                    new GitCommandOption("-e", @"-e", @"Show the email address of each author."), new GitCommandOption("--email", @"--email", @"Show the email address of each author."),
                    new GitCommandOption("--format", @"--format[=<format>]",
                        @"Instead of the commit subject, use some other information to describe each commit. <format> can be any string accepted by the --format option of git log, such as * [%h] %s. (See the ""PRETTY FORMATS"" section of git-log[1].)
Each pretty-printed commit will be rewrapped before it is shown."),
                    new GitCommandOption("-n", @"-n", @"Sort output according to the number of commits per author instead of author alphabetic order."),
                    new GitCommandOption("--numbered", @"--numbered", @"Sort output according to the number of commits per author instead of author alphabetic order."),
                    new GitCommandOption("-s", @"-s", @"Suppress commit description and provide a commit count summary only."),
                    new GitCommandOption("--summary", @"--summary", @"Suppress commit description and provide a commit count summary only."), new GitCommandOption(
                        "-w[<width>[,<indent1>[,<indent2>]]]", @"-w[<width>[,<indent1>[,<indent2>]]]",
                        @"Linewrap the output by wrapping each line at width. The first line of each entry is indented by indent1 spaces, and the second and subsequent lines are indented by indent2 spaces. width, indent1, and indent2 default to 76, 6 and 9 respectively.
If width is 0 (zero) then indent the lines of the output without wrapping them.")
                },
                "show" => new[]
                {
                    new GitCommandOption("--[no-]standard-notes", @"--[no-]standard-notes", @"These options are deprecated. Use the above --notes/--no-notes options instead."),
                    new GitCommandOption("-a", @"-a", @"Treat all files as text."),
                    new GitCommandOption("--abbrev", @"--abbrev[=<n>]",
                        @"Instead of showing the full 40-byte hexadecimal object name in diff-raw format output and diff-tree header lines, show only a partial prefix. This is independent of the --full-index option above, which controls the diff-patch output format. Non default number of digits can be specified with --abbrev=<n>."),
                    new GitCommandOption("--abbrev-commit", @"--abbrev-commit",
                        @"Instead of showing the full 40-byte hexadecimal commit object name, show only a partial prefix. Non default number of digits can be specified with ""--abbrev=<n>"" (which also modifies diff output, if it is displayed).
This should make ""--pretty=oneline"" a whole lot more readable for people using 80-column terminals."),
                    new GitCommandOption("-b", @"-b",
                        @"Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent."),
                    new GitCommandOption("-B[<n>][/<m>]", @"-B[<n>][/<m>]", @"Break complete rewrite changes into pairs of delete and create. This serves two purposes:
It affects the way a change that amounts to a total rewrite of a file not as a series of deletion and insertion mixed together with a very few lines that happen to match textually as the context, but as a single deletion of everything old followed by a single insertion of everything new, and the number m controls this aspect of the -B option (defaults to 60%). -B/70% specifies that less than 30% of the original should remain in the result for Git to consider it a total rewrite (i.e. otherwise the resulting patch will be a series of deletion and insertion mixed together with context lines).
When used with -M, a totally-rewritten file is also considered as the source of a rename (usually -M only considers a file that disappeared as the source of a rename), and the number n controls this aspect of the -B option (defaults to 50%). -B20% specifies that a change with addition and deletion compared to 20% or more of the file''s size are eligible for being picked up as a possible source of a rename to another file."),
                    new GitCommandOption("--binary", @"--binary", @"In addition to --full-index, output a binary diff that can be applied with git-apply."), new GitCommandOption(
                        "--break-rewrites[=[<n>][/<m>]]", @"--break-rewrites[=[<n>][/<m>]]", @"Break complete rewrite changes into pairs of delete and create. This serves two purposes:
It affects the way a change that amounts to a total rewrite of a file not as a series of deletion and insertion mixed together with a very few lines that happen to match textually as the context, but as a single deletion of everything old followed by a single insertion of everything new, and the number m controls this aspect of the -B option (defaults to 60%). -B/70% specifies that less than 30% of the original should remain in the result for Git to consider it a total rewrite (i.e. otherwise the resulting patch will be a series of deletion and insertion mixed together with context lines).
When used with -M, a totally-rewritten file is also considered as the source of a rename (usually -M only considers a file that disappeared as the source of a rename), and the number n controls this aspect of the -B option (defaults to 50%). -B20% specifies that a change with addition and deletion compared to 20% or more of the file''s size are eligible for being picked up as a possible source of a rename to another file."),
                    new GitCommandOption("-C[<n>]", @"-C[<n>]", @"Detect copies as well as renames. See also --find-copies-harder. If n is specified, it has the same meaning as for -M<n>."),
                    new GitCommandOption("--check", @"--check",
                        @"Warn if changes introduce conflict markers or whitespace errors. What are considered whitespace errors is controlled by core.whitespace configuration. By default, trailing whitespaces (including lines that solely consist of whitespaces) and a space character that is immediately followed by a tab character inside the initial indent of the line are considered whitespace errors. Exits with non-zero status if problems are found. Not compatible with --exit-code."),
                    new GitCommandOption("--color", @"--color[=<when>]",
                        @"Show colored diff. --color (i.e. without =<when>) is the same as --color=always. <when> can be one of always, never, or auto."),
                    new GitCommandOption("--color-words", @"--color-words[=<regex>]", @"Equivalent to --word-diff=color plus (if a regex was specified) --word-diff-regex=<regex>."),
                    new GitCommandOption("--compaction-heuristic", @"--compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("-D", @"-D",
                        @"Omit the preimage for deletes, i.e. print only the header but not the diff between the preimage and /dev/null. The resulting patch is not meant to be applied with patch or git apply; this is solely for people who want to just concentrate on reviewing the text after the change. In addition, the output obviously lack enough information to apply such a patch in reverse, even manually, hence the name of the option.
When used together with -B, omit also the preimage in the deletion part of a delete/create pair."),
                    new GitCommandOption("--diff-algorithm={patience|minimal|histogram|myers}",
                        @"--diff-algorithm={patience|minimal|histogram|myers}", @"Choose a diff algorithm. The variants are as follows:
default, myers
The basic greedy diff algorithm. Currently, this is the default.
minimal
Spend extra time to make sure the smallest possible diff is produced.
patience
Use ""patience diff"" algorithm when generating patches.
histogram
This algorithm extends the patience algorithm to ""support low-occurrence common elements"".
For instance, if you configured diff.algorithm variable to a non-default value and want to use the default one, then you have to use --diff-algorithm=default option."),
                    new GitCommandOption("--diff-filter=[(A|C|D|M|R|T|U|X|B)...[*]]", @"--diff-filter=[(A|C|D|M|R|T|U|X|B)...[*]]",
                        @"Select only files that are Added (A), Copied (C), Deleted (D), Modified (M), Renamed (R), have their type (i.e. regular file, symlink, submodule, ...) changed (T), are Unmerged (U), are Unknown (X), or have had their pairing Broken (B). Any combination of the filter characters (including none) can be used. When * (All-or-none) is added to the combination, all paths are selected if there is any file that matches other criteria in the comparison; if there is no file that matches other criteria, nothing is selected.
Also, these upper-case letters can be downcased to exclude. E.g. --diff-filter=ad excludes added and deleted paths."),
                    new GitCommandOption("--dirstat", @"--dirstat[=<param1,param2,...>]",
                        @"Output the distribution of relative amount of changes for each sub-directory. The behavior of --dirstat can be customized by passing it a comma separated list of parameters. The defaults are controlled by the diff.dirstat configuration variable (see git-config[1]). The following parameters are available:
changes
Compute the dirstat numbers by counting the lines that have been removed from the source, or added to the destination. This ignores the amount of pure code movements within a file. In other words, rearranging lines in a file is not counted as much as other changes. This is the default behavior when no parameter is given.
lines
Compute the dirstat numbers by doing the regular line-based diff analysis, and summing the removed/added line counts. (For binary files, count 64-byte chunks instead, since binary files have no natural concept of lines). This is a more expensive --dirstat behavior than the changes behavior, but it does count rearranged lines within a file as much as other changes. The resulting output is consistent with what you get from the other --*stat options.
files
Compute the dirstat numbers by counting the number of files changed. Each changed file counts equally in the dirstat analysis. This is the computationally cheapest --dirstat behavior, since it does not have to look at the file contents at all.
cumulative
Count changes in a child directory for the parent directory as well. Note that when using cumulative, the sum of the percentages reported may exceed 100%. The default (non-cumulative) behavior can be specified with the noncumulative parameter.
<limit>
An integer parameter specifies a cut-off percent (3% by default). Directories contributing less than this percentage of the changes are not shown in the output.
Example: The following will count changed files, while ignoring directories with less than 10% of the total amount of changed files, and accumulating child directory counts in the parent directories: --dirstat=files,10,cumulative."),
                    new GitCommandOption("--dst-prefix", @"--dst-prefix=<prefix>", @"Show the given destination prefix instead of ""b/""."),
                    new GitCommandOption("--encoding", @"--encoding=<encoding>",
                        @"The commit objects record the encoding used for the log message in their encoding header; this option can be used to tell the command to re-code the commit log message in the encoding preferred by the user. For non plumbing commands this defaults to UTF-8. Note that if an object claims to be encoded in X and we are outputting in X, we will output the object verbatim; this means that invalid sequences in the original commit may be copied to the output."),
                    new GitCommandOption("--expand-tabs", @"--expand-tabs",
                        @"Perform a tab expansion (replace each tab with enough spaces to fill to the next display column that is multiple of <n>) in the log message before showing it in the output. --expand-tabs is a short-hand for --expand-tabs=8, and --no-expand-tabs is a short-hand for --expand-tabs=0, which disables tab expansion.
By default, tabs are expanded in pretty formats that indent the log message by 4 spaces (i.e. medium, which is the default, full, and fuller)."),
                    new GitCommandOption("--expand-tabs",
                        @"--expand-tabs=<n>",
                        @"Perform a tab expansion (replace each tab with enough spaces to fill to the next display column that is multiple of <n>) in the log message before showing it in the output. --expand-tabs is a short-hand for --expand-tabs=8, and --no-expand-tabs is a short-hand for --expand-tabs=0, which disables tab expansion.
By default, tabs are expanded in pretty formats that indent the log message by 4 spaces (i.e. medium, which is the default, full, and fuller)."),
                    new GitCommandOption("--ext-diff", @"--ext-diff",
                        @"Allow an external diff helper to be executed. If you set an external diff driver with gitattributes[5], you need to use this option with git-log[1] and friends."),
                    new GitCommandOption("--find-copies", @"--find-copies[=<n>]",
                        @"Detect copies as well as renames. See also --find-copies-harder. If n is specified, it has the same meaning as for -M<n>."),
                    new GitCommandOption("--find-copies-harder", @"--find-copies-harder",
                        @"For performance reasons, by default, -C option finds copies only if the original file of the copy was modified in the same changeset. This flag makes the command inspect unmodified files as candidates for the source of copy. This is a very expensive operation for large projects, so use it with caution. Giving more than one -C option has the same effect."),
                    new GitCommandOption("--find-renames", @"--find-renames[=<n>]",
                        @"If generating diffs, detect and report renames for each commit. For following files across renames while traversing history, see --follow. If n is specified, it is a threshold on the similarity index (i.e. amount of addition/deletions compared to the file''s size). For example, -M90% means Git should consider a delete/add pair to be a rename if more than 90% of the file hasn''t changed. Without a % sign, the number is to be read as a fraction, with a decimal point before it. I.e., -M5 becomes 0.5, and is thus the same as -M50%. Similarly, -M05 is the same as -M5%. To limit detection to exact renames, use -M100%. The default similarity index is 50%."),
                    new GitCommandOption("--format", @"--format=<format>",
                        @"Pretty-print the contents of the commit logs in a given format, where <format> can be one of oneline, short, medium, full, fuller, email, raw, format:<string> and tformat:<string>. When <format> is none of the above, and has %placeholder in it, it acts as if --pretty=tformat:<format> were given.
See the ""PRETTY FORMATS"" section for some additional details for each format. When =<format> part is omitted, it defaults to medium.
Note: you can specify the default pretty format in the repository configuration (see git-config[1])."),
                    new GitCommandOption("--full-index", @"--full-index",
                        @"Instead of the first handful of characters, show the full pre- and post-image blob object names on the ""index"" line when generating patch format output."),
                    new GitCommandOption("--function-context", @"--function-context", @"Show whole surrounding functions of changes."), new GitCommandOption("-G<regex>", @"-G<regex>",
                        @"Look for differences whose patch text contains added/removed lines that match <regex>.
To illustrate the difference between -S<regex> --pickaxe-regex and -G<regex>, consider a commit with the following diff in the same file:
+    return !regexec(regexp, two->ptr, 1, &regmatch, 0);
...
-    hit = !regexec(regexp, mf2.ptr, 1, &regmatch, 0);
While git log -G""regexec\\(regexp"" will show this commit, git log -S""regexec\\(regexp"" --pickaxe-regex will not (because the number of occurrences of that string did not change).
See the pickaxe entry in gitdiffcore[7] for more information."),
                    new GitCommandOption("--histogram", @"--histogram", @"Generate a diff using the ""histogram diff"" algorithm."),
                    new GitCommandOption("--ignore-all-space", @"--ignore-all-space",
                        @"Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other line has none."),
                    new GitCommandOption("--ignore-blank-lines", @"--ignore-blank-lines", @"Ignore changes whose lines are all blank."),
                    new GitCommandOption("--ignore-space-at-eol", @"--ignore-space-at-eol", @"Ignore changes in whitespace at EOL."),
                    new GitCommandOption("--ignore-space-change", @"--ignore-space-change",
                        @"Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent."),
                    new GitCommandOption("--ignore-submodules", @"--ignore-submodules[=<when>]",
                        @"Ignore changes to submodules in the diff generation. <when> can be either ""none"", ""untracked"", ""dirty"" or ""all"", which is the default. Using ""none"" will consider the submodule modified when it either contains untracked or modified files or its HEAD differs from the commit recorded in the superproject and can be used to override any settings of the ignore option in git-config[1] or gitmodules[5]. When ""untracked"" is used submodules are not considered dirty when they only contain untracked content (but they are still scanned for modified content). Using ""dirty"" ignores all changes to the work tree of submodules, only changes to the commits stored in the superproject are shown (this was the behavior until 1.7.0). Using ""all"" hides all changes to submodules."),
                    new GitCommandOption("--indent-heuristic", @"--indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--inter-hunk-context", @"--inter-hunk-context=<lines>",
                        @"Show the context between diff hunks, up to the specified number of lines, thereby fusing hunks that are close to each other."),
                    new GitCommandOption("--irreversible-delete", @"--irreversible-delete",
                        @"Omit the preimage for deletes, i.e. print only the header but not the diff between the preimage and /dev/null. The resulting patch is not meant to be applied with patch or git apply; this is solely for people who want to just concentrate on reviewing the text after the change. In addition, the output obviously lack enough information to apply such a patch in reverse, even manually, hence the name of the option.
When used together with -B, omit also the preimage in the deletion part of a delete/create pair."),
                    new GitCommandOption("--ita-invisible-in-index", @"--ita-invisible-in-index",
                        @"By default entries added by ""git add -N"" appear as an existing empty file in ""git diff"" and a new file in ""git diff --cached"". This option makes the entry appear as a new file in ""git diff"" and non-existent in ""git diff --cached"". This option could be reverted with --ita-visible-in-index. Both options are experimental and could be removed in future."),
                    new GitCommandOption("-l<num>", @"-l<num>",
                        @"The -M and -C options require O(n^2) processing time where n is the number of potential rename/copy targets. This option prevents rename/copy detection from running if the number of rename/copy targets exceeds the specified number."),
                    new GitCommandOption("--line-prefix", @"--line-prefix=<prefix>", @"Prepend an additional prefix to every line of output."),
                    new GitCommandOption("-M[<n>]", @"-M[<n>]",
                        @"If generating diffs, detect and report renames for each commit. For following files across renames while traversing history, see --follow. If n is specified, it is a threshold on the similarity index (i.e. amount of addition/deletions compared to the file''s size). For example, -M90% means Git should consider a delete/add pair to be a rename if more than 90% of the file hasn''t changed. Without a % sign, the number is to be read as a fraction, with a decimal point before it. I.e., -M5 becomes 0.5, and is thus the same as -M50%. Similarly, -M05 is the same as -M5%. To limit detection to exact renames, use -M100%. The default similarity index is 50%."),
                    new GitCommandOption("--minimal", @"--minimal", @"Spend extra time to make sure the smallest possible diff is produced."),
                    new GitCommandOption("--name-only", @"--name-only", @"Show only names of changed files."),
                    new GitCommandOption("--name-status", @"--name-status",
                        @"Show only names and status of changed files. See the description of the --diff-filter option on what the status letters mean."),
                    new GitCommandOption("--no-abbrev-commit", @"--no-abbrev-commit",
                        @"Show the full 40-byte hexadecimal commit object name. This negates --abbrev-commit and those options which imply it such as ""--oneline"". It also overrides the log.abbrevCommit variable."),
                    new GitCommandOption("--no-color", @"--no-color", @"Turn off colored diff. It is the same as --color=never."),
                    new GitCommandOption("--no-compaction-heuristic", @"--no-compaction-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-expand-tabs", @"--no-expand-tabs",
                        @"Perform a tab expansion (replace each tab with enough spaces to fill to the next display column that is multiple of <n>) in the log message before showing it in the output. --expand-tabs is a short-hand for --expand-tabs=8, and --no-expand-tabs is a short-hand for --expand-tabs=0, which disables tab expansion.
By default, tabs are expanded in pretty formats that indent the log message by 4 spaces (i.e. medium, which is the default, full, and fuller)."),
                    new GitCommandOption("--no-ext-diff", @"--no-ext-diff", @"Disallow external diff drivers."),
                    new GitCommandOption("--no-indent-heuristic", @"--no-indent-heuristic",
                        @"These are to help debugging and tuning experimental heuristics (which are off by default) that shift diff hunk boundaries to make patches easier to read."),
                    new GitCommandOption("--no-notes", @"--no-notes",
                        @"Do not show notes. This negates the above --notes option, by resetting the list of notes refs from which notes are shown. Options are parsed in the order given on the command line, so e.g. ""--notes --notes=foo --no-notes --notes=bar"" will only show notes from ""refs/notes/bar""."),
                    new GitCommandOption("--no-patch", @"--no-patch",
                        @"Suppress diff output. Useful for commands like git show that show the patch by default, or to cancel the effect of --patch."),
                    new GitCommandOption("--no-prefix", @"--no-prefix", @"Do not show any source or destination prefix."),
                    new GitCommandOption("--no-renames", @"--no-renames", @"Turn off rename detection, even when the configuration file gives the default to do so."), new GitCommandOption(
                        "--notes", @"--notes[=<treeish>]",
                        @"Show the notes (see git-notes[1]) that annotate the commit, when showing the commit log message. This is the default for git log, git show and git whatchanged commands when there is no --pretty, --format, or --oneline option given on the command line.
By default, the notes shown are from the notes refs listed in the core.notesRef and notes.displayRef variables (or corresponding environment overrides). See git-config[1] for more details.
With an optional <treeish> argument, use the treeish to find the notes to display. The treeish can specify the full refname when it begins with refs/notes/; when it begins with notes/, refs/ and otherwise refs/notes/ is prefixed to form a full name of the ref.
Multiple --notes options can be combined to control which notes are being displayed. Examples: ""--notes=foo"" will show only notes from ""refs/notes/foo""; ""--notes=foo --notes"" will show both notes from ""refs/notes/foo"" and from the default notes ref(s)."),
                    new GitCommandOption("--no-textconv", @"--no-textconv",
                        @"Allow (or disallow) external text conversion filters to be run when comparing binary files. See gitattributes[5] for details. Because textconv filters are typically a one-way conversion, the resulting diff is suitable for human consumption, but cannot be applied. For this reason, textconv filters are enabled by default only for git-diff[1] and git-log[1], but not for git-format-patch[1] or diff plumbing commands."),
                    new GitCommandOption("--numstat", @"--numstat",
                        @"Similar to --stat, but shows number of added and deleted lines in decimal notation and pathname without abbreviation, to make it more machine friendly. For binary files, outputs two - instead of saying 0 0."),
                    new GitCommandOption("-O<orderfile>", @"-O<orderfile>",
                        @"Output the patch in the order specified in the <orderfile>, which has one shell glob pattern per line. This overrides the diff.orderFile configuration variable (see git-config[1]). To cancel diff.orderFile, use -O/dev/null."),
                    new GitCommandOption("--oneline", @"--oneline", @"This is a shorthand for ""--pretty=oneline --abbrev-commit"" used together."),
                    new GitCommandOption("-p", @"-p", @"Generate patch (see section on generating patches)."),
                    new GitCommandOption("--patch", @"--patch", @"Generate patch (see section on generating patches)."),
                    new GitCommandOption("--patch-with-raw", @"--patch-with-raw", @"Synonym for -p --raw."),
                    new GitCommandOption("--patch-with-stat", @"--patch-with-stat", @"Synonym for -p --stat."),
                    new GitCommandOption("--patience", @"--patience", @"Generate a diff using the ""patience diff"" algorithm."),
                    new GitCommandOption("--pickaxe-all", @"--pickaxe-all",
                        @"When -S or -G finds a change, show all the changes in that changeset, not just the files that contain the change in <string>."),
                    new GitCommandOption("--pickaxe-regex", @"--pickaxe-regex", @"Treat the <string> given to -S as an extended POSIX regular expression to match."), new GitCommandOption(
                        "--pretty", @"--pretty[=<format>]",
                        @"Pretty-print the contents of the commit logs in a given format, where <format> can be one of oneline, short, medium, full, fuller, email, raw, format:<string> and tformat:<string>. When <format> is none of the above, and has %placeholder in it, it acts as if --pretty=tformat:<format> were given.
See the ""PRETTY FORMATS"" section for some additional details for each format. When =<format> part is omitted, it defaults to medium.
Note: you can specify the default pretty format in the repository configuration (see git-config[1])."),
                    new GitCommandOption("-R", @"-R", @"Swap two inputs; that is, show differences from index or on-disk file to tree contents."),
                    new GitCommandOption("--raw", @"--raw",
                        @"For each commit, show a summary of changes using the raw diff format. See the ""RAW OUTPUT FORMAT"" section of git-diff[1]. This is different from showing the log itself in raw format, which you can achieve with --format=raw."),
                    new GitCommandOption("--relative", @"--relative[=<path>]",
                        @"When run from a subdirectory of the project, it can be told to exclude changes outside the directory and show pathnames relative to it with this option. When you are not in a subdirectory (e.g. in a bare repository), you can name which subdirectory to make the output relative to by giving a <path> as an argument."),
                    new GitCommandOption("-s", @"-s", @"Suppress diff output. Useful for commands like git show that show the patch by default, or to cancel the effect of --patch."),
                    new GitCommandOption("-S<string>", @"-S<string>",
                        @"Look for differences that change the number of occurrences of the specified string (i.e. addition/deletion) in a file. Intended for the scripter''s use.
It is useful when you''re looking for an exact block of code (like a struct), and want to know the history of that block since it first came into being: use the feature iteratively to feed the interesting block in the preimage back into -S, and keep going until you get the very first version of the block."),
                    new GitCommandOption("--shortstat", @"--shortstat",
                        @"Output only the last line of the --stat format containing total number of modified files, as well as number of added and deleted lines."),
                    new GitCommandOption("--show-notes", @"--show-notes[=<treeish>]", @"These options are deprecated. Use the above --notes/--no-notes options instead."),
                    new GitCommandOption("--show-signature", @"--show-signature",
                        @"Check the validity of a signed commit object by passing the signature to gpg --verify and show the output."),
                    new GitCommandOption("--src-prefix", @"--src-prefix=<prefix>", @"Show the given source prefix instead of ""a/""."), new GitCommandOption(
                        "--stat[[,<name-width>[,<count>]]]", @"--stat[=<width>[,<name-width>[,<count>]]]",
                        @"Generate a diffstat. By default, as much space as necessary will be used for the filename part, and the rest for the graph part. Maximum width defaults to terminal width, or 80 columns if not connected to a terminal, and can be overridden by <width>. The width of the filename part can be limited by giving another width <name-width> after a comma. The width of the graph part can be limited by using --stat-graph-width=<width> (affects all commands generating a stat graph) or by setting diff.statGraphWidth=<width> (does not affect git format-patch). By giving a third parameter <count>, you can limit the output to the first <count> lines, followed by ... if there are more.
These parameters can also be set individually with --stat-width=<width>, --stat-name-width=<name-width> and --stat-count=<count>."),
                    new GitCommandOption("--submodule", @"--submodule[=<format>]",
                        @"Specify how differences in submodules are shown. When specifying --submodule=short the short format is used. This format just shows the names of the commits at the beginning and end of the range. When --submodule or --submodule=log is specified, the log format is used. This format lists the commits in the range like git-submodule[1] summary does. When --submodule=diff is specified, the diff format is used. This format shows an inline diff of the changes in the submodule contents between the commit range. Defaults to diff.submodule or the short format if the config option is unset."),
                    new GitCommandOption("--summary", @"--summary", @"Output a condensed summary of extended header information such as creations, renames and mode changes."),
                    new GitCommandOption("--text", @"--text", @"Treat all files as text."),
                    new GitCommandOption("--textconv", @"--textconv",
                        @"Allow (or disallow) external text conversion filters to be run when comparing binary files. See gitattributes[5] for details. Because textconv filters are typically a one-way conversion, the resulting diff is suitable for human consumption, but cannot be applied. For this reason, textconv filters are enabled by default only for git-diff[1] and git-log[1], but not for git-format-patch[1] or diff plumbing commands."),
                    new GitCommandOption("-u", @"-u", @"Generate patch (see section on generating patches)."),
                    new GitCommandOption("-U<n>", @"-U<n>", @"Generate diffs with <n> lines of context instead of the usual three. Implies -p."),
                    new GitCommandOption("--unified", @"--unified=<n>", @"Generate diffs with <n> lines of context instead of the usual three. Implies -p."),
                    new GitCommandOption("-w", @"-w", @"Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other line has none."),
                    new GitCommandOption("-W", @"-W", @"Show whole surrounding functions of changes."), new GitCommandOption("--word-diff", @"--word-diff[=<mode>]",
                        @"Show a word diff, using the <mode> to delimit changed words. By default, words are delimited by whitespace; see --word-diff-regex below. The <mode> defaults to plain, and must be one of:
color
Highlight changed words using only colors. Implies --color.
plain
Show words as [-removed-] and {+added+}. Makes no attempts to escape the delimiters if they appear in the input, so the output may be ambiguous.
porcelain
Use a special line-based format intended for script consumption. Added/removed/unchanged runs are printed in the usual unified diff format, starting with a +/-/` ` character at the beginning of the line and extending to the end of the line. Newlines in the input are represented by a tilde ~ on a line of its own.
none
Disable word diff again.
Note that despite the name of the first mode, color is used to highlight the changed parts in all modes if enabled."),
                    new GitCommandOption("--word-diff-regex", @"--word-diff-regex=<regex>",
                        @"Use <regex> to decide what a word is, instead of considering runs of non-whitespace to be a word. Also implies --word-diff unless it was already enabled.
Every non-overlapping match of the <regex> is considered a word. Anything between these matches is considered whitespace and ignored(!) for the purposes of finding differences. You may want to append |[^[:space:]] to your regular expression to make sure that it matches all non-whitespace characters. A match that contains a newline is silently truncated(!) at the newline.
For example, --word-diff-regex=. will treat each character as a word and, correspondingly, show differences character by character.
The regex can also be set via a diff driver or configuration option, see gitattributes[5] or git-config[1]. Giving it explicitly overrides any diff driver or configuration setting. Diff drivers override configuration settings."),
                    new GitCommandOption("--ws-error-highlight", @"--ws-error-highlight=<kind>",
                        @"Highlight whitespace errors on lines specified by <kind> in the color specified by color.diff.whitespace. <kind> is a comma separated list of old, new, context. When this option is not given, only whitespace errors in new lines are highlighted. E.g. --ws-error-highlight=new,old highlights whitespace errors on both deleted and added lines. all can be used as a short-hand for old,new,context. The diff.wsErrorHighlight configuration variable can be used to specify the default behaviour."),
                    new GitCommandOption("-z", @"-z", @"Separate the commits with NULs instead of with new newlines.
Also, when --raw or --numstat has been given, do not munge pathnames and use NULs as output field terminators.
Without this option, each pathname output will have TAB, LF, double quotes, and backslash characters replaced with \\t, \\n, \\"", and \\\\, respectively, and the pathname will be enclosed in double quotes if any of those replacements occurred.")
                },
                "stash" => System.Array.Empty<GitCommandOption>(),
                "status" => new[]
                {
                    new GitCommandOption("-b", @"-b", @"Show the branch and tracking info even in short-format."),
                    new GitCommandOption("--branch", @"--branch", @"Show the branch and tracking info even in short-format."),
                    new GitCommandOption("--column", @"--column[=<options>]",
                        @"Display untracked files in columns. See configuration variable column.status for option syntax.--column and --no-column without options are equivalent to always and never respectively."),
                    new GitCommandOption("--ignored", @"--ignored", @"Show ignored files as well."),
                    new GitCommandOption("--ignore-submodules", @"--ignore-submodules[=<when>]",
                        @"Ignore changes to submodules when looking for changes. <when> can be either ""none"", ""untracked"", ""dirty"" or ""all"", which is the default. Using ""none"" will consider the submodule modified when it either contains untracked or modified files or its HEAD differs from the commit recorded in the superproject and can be used to override any settings of the ignore option in git-config[1] or gitmodules[5]. When ""untracked"" is used submodules are not considered dirty when they only contain untracked content (but they are still scanned for modified content). Using ""dirty"" ignores all changes to the work tree of submodules, only changes to the commits stored in the superproject are shown (this was the behavior before 1.7.0). Using ""all"" hides all changes to submodules (and suppresses the output of submodule summaries when the config option status.submoduleSummary is set)."),
                    new GitCommandOption("--long", @"--long", @"Give the output in the long-format. This is the default."),
                    new GitCommandOption("--no-column", @"--no-column",
                        @"Display untracked files in columns. See configuration variable column.status for option syntax.--column and --no-column without options are equivalent to always and never respectively."),
                    new GitCommandOption("--porcelain", @"--porcelain[=<version>]",
                        @"Give the output in an easy-to-parse format for scripts. This is similar to the short output, but will remain stable across Git versions and regardless of user configuration. See below for details.
The version parameter is used to specify the format version. This is optional and defaults to the original version v1 format."),
                    new GitCommandOption("-s", @"-s", @"Give the output in the short-format."), new GitCommandOption("--short", @"--short", @"Give the output in the short-format."),
                    new GitCommandOption("-u[<mode>]", @"-u[<mode>]", @"Show untracked files.
The mode parameter is used to specify the handling of untracked files. It is optional: it defaults to all, and if specified, it must be stuck to the option (e.g. -uno, but not -u no).
The possible options are:
no - Show no untracked files.
normal - Shows untracked files and directories.
all - Also shows individual files in untracked directories.
When -u option is not used, untracked files and directories are shown (i.e. the same as specifying normal), to help you avoid forgetting to add newly created files. Because it takes extra work to find untracked files in the filesystem, this mode may take some time in a large working tree. Consider enabling untracked cache and split index if supported (see git update-index --untracked-cache and git update-index --split-index), Otherwise you can use no to have git status return more quickly without showing untracked files.
The default can be changed using the status.showUntrackedFiles configuration variable documented in git-config[1]."),
                    new GitCommandOption("--untracked-files", @"--untracked-files[=<mode>]", @"Show untracked files.
The mode parameter is used to specify the handling of untracked files. It is optional: it defaults to all, and if specified, it must be stuck to the option (e.g. -uno, but not -u no).
The possible options are:
no - Show no untracked files.
normal - Shows untracked files and directories.
all - Also shows individual files in untracked directories.
When -u option is not used, untracked files and directories are shown (i.e. the same as specifying normal), to help you avoid forgetting to add newly created files. Because it takes extra work to find untracked files in the filesystem, this mode may take some time in a large working tree. Consider enabling untracked cache and split index if supported (see git update-index --untracked-cache and git update-index --split-index), Otherwise you can use no to have git status return more quickly without showing untracked files.
The default can be changed using the status.showUntrackedFiles configuration variable documented in git-config[1]."),
                    new GitCommandOption("-v", @"-v",
                        @"In addition to the names of files that have been changed, also show the textual changes that are staged to be committed (i.e., like the output of git diff --cached). If -v is specified twice, then also show the changes in the working tree that have not yet been staged (i.e., like the output of git diff)."),
                    new GitCommandOption("--verbose", @"--verbose",
                        @"In addition to the names of files that have been changed, also show the textual changes that are staged to be committed (i.e., like the output of git diff --cached). If -v is specified twice, then also show the changes in the working tree that have not yet been staged (i.e., like the output of git diff)."),
                    new GitCommandOption("-z", @"-z", @"Terminate entries with NUL, instead of LF. This implies the --porcelain=v1 output format if no other format is given.")
                },
                "submodule" => new[]
                {
                    new GitCommandOption("--[no-]recommend-shallow", @"--[no-]recommend-shallow",
                        @"This option is only valid for the update command. The initial clone of a submodule will use the recommended submodule.<name>.shallow as provided by the .gitmodules file by default. To ignore the suggestions use --no-recommend-shallow."),
                    new GitCommandOption("--all", @"--all", @"This option is only valid for the deinit command. Unregister all submodules in the working tree."),
                    new GitCommandOption("-b", @"-b",
                        @"Branch of repository to add as submodule. The name of the branch is recorded as submodule.<name>.branch in .gitmodules for update --remote. A special value of . is used to indicate that the name of the branch in the submodule should be the same name as the current branch in the current repository."),
                    new GitCommandOption("--branch", @"--branch",
                        @"Branch of repository to add as submodule. The name of the branch is recorded as submodule.<name>.branch in .gitmodules for update --remote. A special value of . is used to indicate that the name of the branch in the submodule should be the same name as the current branch in the current repository."),
                    new GitCommandOption("--cached", @"--cached",
                        @"This option is only valid for status and summary commands. These commands typically use the commit found in the submodule HEAD, but with this option, the commit stored in the index is used instead."),
                    new GitCommandOption("--checkout", @"--checkout",
                        @"This option is only valid for the update command. Checkout the commit recorded in the superproject on a detached HEAD in the submodule. This is the default behavior, the main use of this option is to override submodule.$name.update when set to a value other than checkout. If the key submodule.$name.update is either not explicitly set or set to checkout, this option is implicit."),
                    new GitCommandOption("--depth", @"--depth",
                        @"This option is valid for add and update commands. Create a shallow clone with a history truncated to the specified number of revisions. See git-clone[1]"),
                    new GitCommandOption("-f", @"-f",
                        @"This option is only valid for add, deinit and update commands. When running add, allow adding an otherwise ignored submodule path. When running deinit the submodule working trees will be removed even if they contain local changes. When running update (only effective with the checkout procedure), throw away local changes in submodules when switching to a different commit; and always run a checkout operation in the submodule, even if the commit listed in the index of the containing repository matches the commit checked out in the submodule."),
                    new GitCommandOption("--files", @"--files",
                        @"This option is only valid for the summary command. This command compares the commit in the index with that in the submodule HEAD when this option is used."),
                    new GitCommandOption("--force", @"--force",
                        @"This option is only valid for add, deinit and update commands. When running add, allow adding an otherwise ignored submodule path. When running deinit the submodule working trees will be removed even if they contain local changes. When running update (only effective with the checkout procedure), throw away local changes in submodules when switching to a different commit; and always run a checkout operation in the submodule, even if the commit listed in the index of the containing repository matches the commit checked out in the submodule."),
                    new GitCommandOption("--init", @"--init",
                        @"This option is only valid for the update command. Initialize all submodules for which ""git submodule init"" has not been called so far before updating."),
                    new GitCommandOption("-j", @"-j <n>",
                        @"This option is only valid for the update command. Clone new submodules in parallel with as many jobs. Defaults to the submodule.fetchJobs option."),
                    new GitCommandOption("--jobs", @"--jobs <n>",
                        @"This option is only valid for the update command. Clone new submodules in parallel with as many jobs. Defaults to the submodule.fetchJobs option."),
                    new GitCommandOption("--merge", @"--merge",
                        @"This option is only valid for the update command. Merge the commit recorded in the superproject into the current branch of the submodule. If this option is given, the submodule''s HEAD will not be detached. If a merge failure prevents this process, you will have to resolve the resulting conflicts within the submodule with the usual conflict resolution tools. If the key submodule.$name.update is set to merge, this option is implicit."),
                    new GitCommandOption("-N", @"-N", @"This option is only valid for the update command. Don't fetch new objects from the remote site."),
                    new GitCommandOption("-n", @"-n",
                        @"This option is only valid for the summary command. Limit the summary size (number of commits shown in total). Giving 0 will disable the summary; a negative number means unlimited (the default). This limit only applies to modified submodules. The size is always limited to 1 for added/deleted/typechanged submodules."),
                    new GitCommandOption("--name", @"--name",
                        @"This option is only valid for the add command. It sets the submodule''s name to the given string instead of defaulting to its path. The name must be valid as a directory name and may not end with a /."),
                    new GitCommandOption("--no-fetch", @"--no-fetch", @"This option is only valid for the update command. Don't fetch new objects from the remote site."),
                    new GitCommandOption("-q", @"-q", @"Only print error messages."), new GitCommandOption("--quiet", @"--quiet", @"Only print error messages."),
                    new GitCommandOption("--rebase", @"--rebase",
                        @"This option is only valid for the update command. Rebase the current branch onto the commit recorded in the superproject. If this option is given, the submodule''s HEAD will not be detached. If a merge failure prevents this process, you will have to resolve these failures with git-rebase[1]. If the key submodule.$name.update is set to rebase, this option is implicit."),
                    new GitCommandOption("--recursive", @"--recursive",
                        @"This option is only valid for foreach, update, status and sync commands. Traverse submodules recursively. The operation is performed not only in the submodules of the current repo, but also in any nested submodules inside those submodules (and so on)."),
                    new GitCommandOption("--reference", @"--reference <repository>",
                        @"This option is only valid for add and update commands. These commands sometimes need to clone a remote repository. In this case, this option will be passed to the git-clone[1] command.
NOTE: Do not use this option unless you have read the note for git-clone[1]''s --reference and --shared options carefully."),
                    new GitCommandOption("--remote", @"--remote",
                        @"This option is only valid for the update command. Instead of using the superproject''s recorded SHA-1 to update the submodule, use the status of the submodule''s remote-tracking branch. The remote used is branch''s remote (branch.<name>.remote), defaulting to origin. The remote branch used defaults to master, but the branch name may be overridden by setting the submodule.<name>.branch option in either .gitmodules or .git/config (with .git/config taking precedence).
This works for any of the supported update procedures (--checkout, --rebase, etc.). The only change is the source of the target SHA-1. For example, submodule update --remote --merge will merge upstream submodule changes into the submodules, while submodule update --merge will merge superproject gitlink changes into the submodules.
In order to ensure a current tracking branch state, update --remote fetches the submodule''s remote repository before calculating the SHA-1. If you don''t want to fetch, you should use submodule update --remote --no-fetch.
Use this option to integrate changes from the upstream subproject with your submodule''s current HEAD. Alternatively, you can run git pull from the submodule, which is equivalent except for the remote branch name: update --remote uses the default upstream repository and submodule.<name>.branch, while git pull uses the submodule''s branch.<name>.merge. Prefer submodule.<name>.branch if you want to distribute the default upstream branch with the superproject and branch.<name>.merge if you want a more native feel while working in the submodule itself."),
                    new GitCommandOption("--summary-limit", @"--summary-limit",
                        @"This option is only valid for the summary command. Limit the summary size (number of commits shown in total). Giving 0 will disable the summary; a negative number means unlimited (the default). This limit only applies to modified submodules. The size is always limited to 1 for added/deleted/typechanged submodules.")
                },
                "svn" => new[]
                {
                    new GitCommandOption("-", @"-", @"Only used with the set-tree command.
Read a list of commits from stdin and commit them in reverse order. Only the leading sha1 is read from each line, so git rev-list --pretty=oneline output can be used."),
                    new GitCommandOption("-A", @"-A",
                        @"Don''t require an exact match if given an SVN revision; if there is not an exact match return the closest match searching forward in the history."),
                    new GitCommandOption("-A<filename>", @"-A<filename>", @"Syntax is compatible with the file used by git cvsimport:
	loginname = Joe User <user@example.com>
If this option is specified and git svn encounters an SVN committer name that does not exist in the authors-file, git svn will abort operation. The user will then have to add the appropriate entry. Re-running the previous git svn command after the authors-file is modified should continue operation.
config key: svn.authorsfile"),
                    new GitCommandOption("--add-author-from", @"--add-author-from",
                        @"When committing to svn from Git (as part of commit-diff, set-tree or dcommit operations), if the existing log message doesn''t already have a From: or Signed-off-by: line, append a From: line based on the Git commit''s author string. If you use this, then --use-log-author will retrieve a valid author string for all commits."),
                    new GitCommandOption("--after", @"--after",
                        @"Don''t require an exact match if given an SVN revision; if there is not an exact match return the closest match searching forward in the history."),
                    new GitCommandOption("--authors-file", @"--authors-file=<filename>", @"Syntax is compatible with the file used by git cvsimport:
	loginname = Joe User <user@example.com>
If this option is specified and git svn encounters an SVN committer name that does not exist in the authors-file, git svn will abort operation. The user will then have to add the appropriate entry. Re-running the previous git svn command after the authors-file is modified should continue operation.
config key: svn.authorsfile"),
                    new GitCommandOption("--authors-prog", @"--authors-prog=<filename>",
                        @"If this option is specified, for each SVN committer name that does not exist in the authors file, the given file is executed with the committer name as the first argument. The program is expected to return a single line of the form ""Name <email>"", which will be treated as if included in the authors file.
config key: svn.authorsProg"),
                    new GitCommandOption("-B", @"-B",
                        @"Don''t require an exact match if given an SVN revision, instead find the commit corresponding to the state of the SVN repository (on the current branch) at the specified revision."),
                    new GitCommandOption("-b<branches_subdir>", @"-b<branches_subdir>",
                        @"These are optional command-line options for init. Each of these flags can point to a relative repository path (--tags=project/tags) or a full url (--tags=https://foo.org/project/tags). You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths. The option --stdlayout is a shorthand way of setting trunk,tags,branches as the relative paths, which is the Subversion default. If any of the other options are given as well, they take precedence."),
                    new GitCommandOption("--before", @"--before",
                        @"Don''t require an exact match if given an SVN revision, instead find the commit corresponding to the state of the SVN repository (on the current branch) at the specified revision."),
                    new GitCommandOption("--branches", @"--branches=<branches_subdir>",
                        @"These are optional command-line options for init. Each of these flags can point to a relative repository path (--tags=project/tags) or a full url (--tags=https://foo.org/project/tags). You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths. The option --stdlayout is a shorthand way of setting trunk,tags,branches as the relative paths, which is the Subversion default. If any of the other options are given as well, they take precedence."),
                    new GitCommandOption("--commit-url", @"--commit-url <URL>",
                        @"Commit to this SVN URL (the full path). This is intended to allow existing git svn repositories created with one transport method (e.g. svn:// or http:// for anonymous read) to be reused if a user is later given access to an alternate transport method (e.g. svn+ssh:// or https://) for commit.
config key: svn-remote.<name>.commiturl
config key: svn.commiturl (overwrites all svn-remote.<name>.commiturl options)
Note that the SVN URL of the commiturl config key includes the SVN branch. If you rather want to set the commit URL for an entire SVN repository use svn-remote.<name>.pushurl instead.
Using this option for any other purpose (don''t ask) is very strongly discouraged."),
                    new GitCommandOption("--commit-url", @"--commit-url",
                        @"Use the specified URL to connect to the destination Subversion repository. This is useful in cases where the source SVN repository is read-only. This option overrides configuration property commiturl.
git config --get-all svn-remote.<name>.commiturl"),
                    new GitCommandOption("-d<path>", @"-d<path>",
                        @"If more than one --branches (or --tags) option was given to the init or clone command, you must provide the location of the branch (or tag) you wish to create in the SVN repository. <path> specifies which path to use to create the branch or tag and should match the pattern on the left-hand side of one of the configured branches or tags refspecs. You can see these refspecs with the commands
git config --get-all svn-remote.<name>.branches
git config --get-all svn-remote.<name>.tags
where <name> is the name of the SVN repository as specified by the -R option to init (or ""svn"" by default)."),
                    new GitCommandOption("--destination", @"--destination=<path>",
                        @"If more than one --branches (or --tags) option was given to the init or clone command, you must provide the location of the branch (or tag) you wish to create in the SVN repository. <path> specifies which path to use to create the branch or tag and should match the pattern on the left-hand side of one of the configured branches or tags refspecs. You can see these refspecs with the commands
git config --get-all svn-remote.<name>.branches
git config --get-all svn-remote.<name>.tags
where <name> is the name of the SVN repository as specified by the -R option to init (or ""svn"" by default)."),
                    new GitCommandOption("--dry-run", @"--dry-run",
                        @"This can be used with the dcommit, rebase, branch and tag commands.
For dcommit, print out the series of Git arguments that would show which diffs would be committed to SVN.
For rebase, display the local branch associated with the upstream svn repository associated with the current branch and the URL of svn repository that will be fetched from.
For branch and tag, display the urls that will be used for copying when creating the branch or tag."),
                    new GitCommandOption("-e", @"-e", @"Only used with the dcommit, set-tree and commit-diff commands.
Edit the commit message before committing to SVN. This is off by default for objects that are commits, and forced on when committing tree objects.
config key: svn.edit"),
                    new GitCommandOption("--edit", @"--edit", @"Only used with the dcommit, set-tree and commit-diff commands.
Edit the commit message before committing to SVN. This is off by default for objects that are commits, and forced on when committing tree objects.
config key: svn.edit"),
                    new GitCommandOption("--find-copies-harder", @"--find-copies-harder", @"Only used with the dcommit, set-tree and commit-diff commands.
They are both passed directly to git diff-tree; see git-diff-tree[1] for more information.
config key: svn.l
config key: svn.findcopiesharder"),
                    new GitCommandOption("--follow-parent", @"--follow-parent",
                        @"This option is only relevant if we are tracking branches (using one of the repository layout options --trunk, --tags, --branches, --stdlayout). For each tracked branch, try to find out where its revision was copied from, and set a suitable parent in the first Git commit for the branch. This is especially helpful when we''re tracking a directory that has been moved around within the repository. If this feature is disabled, the branches created by git svn will all be linear and not share any history, meaning that there will be no information on where branches were branched off or merged. However, following long/convoluted histories can take a long time, so disabling this feature may speed up the cloning process. This feature is enabled by default, use --no-follow-parent to disable it.
config key: svn.followparent"),
                    new GitCommandOption("--git-format", @"--git-format",
                        @"Produce output in the same format as git blame, but with SVN revision numbers instead of Git commit hashes. In this mode, changes that haven''t been committed to SVN (including local working-copy edits) are shown as revision 0."),
                    new GitCommandOption("-i<GIT_SVN_ID>", @"-i<GIT_SVN_ID>",
                        @"This sets GIT_SVN_ID (instead of using the environment). This allows the user to override the default refname to fetch from when tracking a single URL. The log and dcommit commands no longer require this switch as an argument."),
                    new GitCommandOption("--id", @"--id <GIT_SVN_ID>",
                        @"This sets GIT_SVN_ID (instead of using the environment). This allows the user to override the default refname to fetch from when tracking a single URL. The log and dcommit commands no longer require this switch as an argument."),
                    new GitCommandOption("--ignore-paths", @"--ignore-paths=<regex>",
                        @"This allows one to specify a Perl regular expression that will cause skipping of all matching paths from checkout from SVN. The --ignore-paths option should match for every fetch (including automatic fetches due to clone, dcommit, rebase, etc) on a given repository.
config key: svn-remote.<name>.ignore-paths
If the ignore-paths configuration key is set, and the command-line option is also given, both regular expressions will be used.
Examples:
Skip ""doc*"" directory for every fetch
--ignore-paths=""^doc""
Skip ""branches"" and ""tags"" of first level directories
--ignore-paths=""^[^/]+/(?:branches|tags)"""),
                    new GitCommandOption("--ignore-paths", @"--ignore-paths=<regex>",
                        @"When passed to init or clone this regular expression will be preserved as a config key. See fetch for a description of --ignore-paths."),
                    new GitCommandOption("--include-paths", @"--include-paths=<regex>",
                        @"This allows one to specify a Perl regular expression that will cause the inclusion of only matching paths from checkout from SVN. The --include-paths option should match for every fetch (including automatic fetches due to clone, dcommit, rebase, etc) on a given repository. --ignore-paths takes precedence over --include-paths.
config key: svn-remote.<name>.include-paths"),
                    new GitCommandOption("--include-paths", @"--include-paths=<regex>",
                        @"When passed to init or clone this regular expression will be preserved as a config key. See fetch for a description of --include-paths."),
                    new GitCommandOption("--incremental", @"--incremental", @"supported"), new GitCommandOption("--interactive", @"--interactive",
                        @"Ask the user to confirm that a patch set should actually be sent to SVN. For each patch, one may answer ""yes"" (accept this patch), ""no"" (discard this patch), ""all"" (accept all patches), or ""quit"".
git svn dcommit returns immediately if answer is ""no"" or ""quit"", without committing anything to SVN."),
                    new GitCommandOption("-l", @"-l", @"Do not fetch remotely; only run git rebase against the last fetched commit from the upstream SVN."), new GitCommandOption("-l<num>",
                        @"-l<num>", @"Only used with the dcommit, set-tree and commit-diff commands.
They are both passed directly to git diff-tree; see git-diff-tree[1] for more information.
config key: svn.l
config key: svn.findcopiesharder"),
                    new GitCommandOption("--limit", @"--limit=<n>", @"is NOT the same as --max-count, doesn't count merged/excluded commits"),
                    new GitCommandOption("--local", @"--local", @"Do not fetch remotely; only run git rebase against the last fetched commit from the upstream SVN."), new GitCommandOption(
                        "--localtime", @"--localtime",
                        @"Store Git commit times in the local time zone instead of UTC. This makes git log (even without --date=local) show the same times that svn log would in the local time zone.
This doesn''t interfere with interoperating with the Subversion repository you cloned from, but if you wish for your local Git repository to be able to interoperate with someone else''s local Git repository, either don''t use this option or you should both use it in the same local time zone."),
                    new GitCommandOption("--log-window-size", @"--log-window-size=<n>",
                        @"Fetch <n> log entries per request when scanning Subversion history. The default is 100. For very large Subversion repositories, larger values may be needed for clone/fetch to complete in reasonable time. But overly large values may lead to higher memory usage and request timeouts."),
                    new GitCommandOption("-m", @"-m", @"Allows to specify the commit message."), new GitCommandOption("-m", @"-m", @"These are only used with the dcommit and rebase commands.
Passed directly to git rebase when using dcommit if a git reset cannot be used (see dcommit)."),
                    new GitCommandOption("--merge", @"--merge", @"These are only used with the dcommit and rebase commands.
Passed directly to git rebase when using dcommit if a git reset cannot be used (see dcommit)."),
                    new GitCommandOption("--mergeinfo", @"--mergeinfo=<mergeinfo>",
                        @"Add the given merge information during the dcommit (e.g. --mergeinfo=""/branches/foo:1-10""). All svn server versions can store this information (as a property), and svn clients starting from version 1.5 can make use of it. To specify merge information from multiple branches, use a single space character between the branches (--mergeinfo=""/branches/foo:1-10 /branches/bar:3,5-6,8"")
config key: svn.pushmergeinfo
This option will cause git-svn to attempt to automatically populate the svn:mergeinfo property in the SVN repository when possible. Currently, this can only be done when dcommitting non-fast-forward merges where all parents but the first have already been pushed into SVN."),
                    new GitCommandOption("--message", @"--message", @"Allows to specify the commit message."), new GitCommandOption("-n", @"-n",
                        @"This can be used with the dcommit, rebase, branch and tag commands.
For dcommit, print out the series of Git arguments that would show which diffs would be committed to SVN.
For rebase, display the local branch associated with the upstream svn repository associated with the current branch and the URL of svn repository that will be fetched from.
For branch and tag, display the urls that will be used for copying when creating the branch or tag."),
                    new GitCommandOption("--no-metadata", @"--no-metadata",
                        @"Set the noMetadata option in the [svn-remote] config. This option is not recommended, please read the svn.noMetadata section of this manpage before using this option."),
                    new GitCommandOption("--no-minimize-url", @"--no-minimize-url",
                        @"When tracking multiple directories (using --stdlayout, --branches, or --tags options), git svn will attempt to connect to the root (or highest allowed level) of the Subversion repository. This default allows better tracking of history if entire projects are moved within a repository, but may cause issues on repositories where read access restrictions are in place. Passing --no-minimize-url will allow git svn to accept URLs as-is without attempting to connect to a higher level directory. This option is off by default when only one URL/branch is tracked (it would do little good)."),
                    new GitCommandOption("--no-rebase", @"--no-rebase", @"After committing, do not rebase or reset."),
                    new GitCommandOption("--oneline", @"--oneline", @"our version of --pretty=oneline"),
                    new GitCommandOption("-p", @"-p", @"Discard the specified revision as well, keeping the nearest parent instead."), new GitCommandOption("-p", @"-p",
                        @"These are only used with the dcommit and rebase commands.
Passed directly to git rebase when using dcommit if a git reset cannot be used (see dcommit)."),
                    new GitCommandOption("--parent", @"--parent", @"Discard the specified revision as well, keeping the nearest parent instead."),
                    new GitCommandOption("--parent", @"--parent", @"Fetch only from the SVN parent of the current HEAD."),
                    new GitCommandOption("--parents", @"--parents",
                        @"Create parent folders. This parameter is equivalent to the parameter --parents on svn cp commands and is useful for non-standard repository layouts."),
                    new GitCommandOption("--placeholder-filename", @"--placeholder-filename=<filename>",
                        @"Set the name of placeholder files created by --preserve-empty-dirs. Default: "".gitignore"""),
                    new GitCommandOption("--prefix", @"--prefix=<prefix>",
                        @"This allows one to specify a prefix which is prepended to the names of remotes if trunk/branches/tags are specified. The prefix does not automatically include a trailing slash, so be sure you include one in the argument if that is what you want. If --branches/-b is specified, the prefix must include a trailing slash. Setting a prefix (with a trailing slash) is strongly encouraged in any case, as your SVN-tracking refs will then be located at ""refs/remotes/$prefix/"", which is compatible with Git''s own remote-tracking ref layout (refs/remotes/$remote/). Setting a prefix is also useful if you wish to track multiple projects that share a common repository. By default, the prefix is set to origin/.
Note
Before Git v2.0, the default prefix was """" (no prefix). This meant that SVN-tracking refs were put at ""refs/remotes/*"", which is incompatible with how Git''s own remote-tracking refs are organized. If you still want the old default, you can get it by passing --prefix """" on the command line (--prefix="""" may not work if your Perl''s Getopt::Long is < v2.37)."),
                    new GitCommandOption("--preserve-empty-dirs", @"--preserve-empty-dirs",
                        @"Create a placeholder file in the local Git repository for each empty directory fetched from Subversion. This includes directories that become empty by removing all entries in the Subversion repository (but not the directory itself). The placeholder files are also tracked and removed when no longer necessary."),
                    new GitCommandOption("--preserve-merges", @"--preserve-merges", @"These are only used with the dcommit and rebase commands.
Passed directly to git rebase when using dcommit if a git reset cannot be used (see dcommit)."),
                    new GitCommandOption("-q", @"-q", @"Make git svn less verbose. Specify a second time to make it even less verbose."),
                    new GitCommandOption("--quiet", @"--quiet", @"Make git svn less verbose. Specify a second time to make it even less verbose."),
                    new GitCommandOption("-r", @"-r <n>", @"Specify the most recent revision to keep. All later revisions are discarded."), new GitCommandOption("-r", @"-r <arg>",
                        @"Used with the fetch command.
This allows revision ranges for partial/cauterized history to be supported. $NUMBER, $NUMBER1:$NUMBER2 (numeric ranges), $NUMBER:HEAD, and BASE:$NUMBER are all supported.
This can allow you to make partial mirrors when running fetch; but is generally not recommended because history will be skipped and lost."),
                    new GitCommandOption("-r[:<n>]", @"-r <n>[:<n>]", @"is supported, non-numeric args are not: HEAD, NEXT, BASE, PREV, etc ..."),
                    new GitCommandOption("-R<remote name>", @"-R<remote name>",
                        @"Specify the [svn-remote ""<remote name>""] section to use, this allows SVN multiple repositories to be tracked. Default: ""svn"""),
                    new GitCommandOption("--revision", @"--revision=<n>", @"Specify the most recent revision to keep. All later revisions are discarded."), new GitCommandOption("--revision",
                        @"--revision <arg>", @"Used with the fetch command.
This allows revision ranges for partial/cauterized history to be supported. $NUMBER, $NUMBER1:$NUMBER2 (numeric ranges), $NUMBER:HEAD, and BASE:$NUMBER are all supported.
This can allow you to make partial mirrors when running fetch; but is generally not recommended because history will be skipped and lost."),
                    new GitCommandOption("--revision[:<n>]", @"--revision=<n>[:<n>]", @"is supported, non-numeric args are not: HEAD, NEXT, BASE, PREV, etc ..."),
                    new GitCommandOption("--rewrite-root", @"--rewrite-root=<URL>", @"Set the rewriteRoot option in the [svn-remote] config."),
                    new GitCommandOption("--rewrite-uuid", @"--rewrite-uuid=<UUID>", @"Set the rewriteUUID option in the [svn-remote] config."), new GitCommandOption("--rmdir", @"--rmdir",
                        @"Only used with the dcommit, set-tree and commit-diff commands.
Remove directories from the SVN tree if there are no files left behind. SVN can version empty directories, and they are not removed by default if there are no files left in them. Git cannot version empty directories. Enabling this flag will make the commit to SVN act like Git.
config key: svn.rmdir"),
                    new GitCommandOption("-s", @"-s",
                        @"These are optional command-line options for init. Each of these flags can point to a relative repository path (--tags=project/tags) or a full url (--tags=https://foo.org/project/tags). You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths. The option --stdlayout is a shorthand way of setting trunk,tags,branches as the relative paths, which is the Subversion default. If any of the other options are given as well, they take precedence."),
                    new GitCommandOption("-s<strategy>", @"-s<strategy>", @"These are only used with the dcommit and rebase commands.
Passed directly to git rebase when using dcommit if a git reset cannot be used (see dcommit)."),
                    new GitCommandOption("--shared[=(false|true|umask|group|all|world|everybody)]", @"--shared[=(false|true|umask|group|all|world|everybody)]",
                        @"Only used with the init command. These are passed directly to git init."),
                    new GitCommandOption("--show-commit", @"--show-commit", @"shows the Git commit sha1, as well"), new GitCommandOption("--stdin", @"--stdin",
                        @"Only used with the set-tree command.
Read a list of commits from stdin and commit them in reverse order. Only the leading sha1 is read from each line, so git rev-list --pretty=oneline output can be used."),
                    new GitCommandOption("--stdlayout", @"--stdlayout",
                        @"These are optional command-line options for init. Each of these flags can point to a relative repository path (--tags=project/tags) or a full url (--tags=https://foo.org/project/tags). You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths. The option --stdlayout is a shorthand way of setting trunk,tags,branches as the relative paths, which is the Subversion default. If any of the other options are given as well, they take precedence."),
                    new GitCommandOption("--strategy", @"--strategy=<strategy>", @"These are only used with the dcommit and rebase commands.
Passed directly to git rebase when using dcommit if a git reset cannot be used (see dcommit)."),
                    new GitCommandOption("--svn-remote", @"--svn-remote <remote name>",
                        @"Specify the [svn-remote ""<remote name>""] section to use, this allows SVN multiple repositories to be tracked. Default: ""svn"""),
                    new GitCommandOption("-t", @"-t", @"Create a tag by using the tags_subdir instead of the branches_subdir specified during git svn init."),
                    new GitCommandOption("-t<tags_subdir>", @"-t<tags_subdir>",
                        @"These are optional command-line options for init. Each of these flags can point to a relative repository path (--tags=project/tags) or a full url (--tags=https://foo.org/project/tags). You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths. The option --stdlayout is a shorthand way of setting trunk,tags,branches as the relative paths, which is the Subversion default. If any of the other options are given as well, they take precedence."),
                    new GitCommandOption("-T<trunk_subdir>", @"-T<trunk_subdir>",
                        @"These are optional command-line options for init. Each of these flags can point to a relative repository path (--tags=project/tags) or a full url (--tags=https://foo.org/project/tags). You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths. The option --stdlayout is a shorthand way of setting trunk,tags,branches as the relative paths, which is the Subversion default. If any of the other options are given as well, they take precedence."),
                    new GitCommandOption("--tag", @"--tag", @"Create a tag by using the tags_subdir instead of the branches_subdir specified during git svn init."),
                    new GitCommandOption("--tags", @"--tags=<tags_subdir>",
                        @"These are optional command-line options for init. Each of these flags can point to a relative repository path (--tags=project/tags) or a full url (--tags=https://foo.org/project/tags). You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths. The option --stdlayout is a shorthand way of setting trunk,tags,branches as the relative paths, which is the Subversion default. If any of the other options are given as well, they take precedence."),
                    new GitCommandOption("--template", @"--template=<template_directory>", @"Only used with the init command. These are passed directly to git init."),
                    new GitCommandOption("--trunk", @"--trunk=<trunk_subdir>",
                        @"These are optional command-line options for init. Each of these flags can point to a relative repository path (--tags=project/tags) or a full url (--tags=https://foo.org/project/tags). You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths. The option --stdlayout is a shorthand way of setting trunk,tags,branches as the relative paths, which is the Subversion default. If any of the other options are given as well, they take precedence."),
                    new GitCommandOption("--use-log-author", @"--use-log-author",
                        @"When retrieving svn commits into Git (as part of fetch, rebase, or dcommit operations), look for the first From: or Signed-off-by: line in the log message and use that as the author string."),
                    new GitCommandOption("--username", @"--username", @"Specify the SVN username to perform the commit as. This option overrides the username configuration property."),
                    new GitCommandOption("--username", @"--username=<user>",
                        @"For transports that SVN handles authentication for (http, https, and plain svn), specify the username. For other transports (e.g. svn+ssh://), you must include the username in the URL, e.g. svn+ssh://foo@svn.bar.com/project"),
                    new GitCommandOption("--use-svm-props", @"--use-svm-props", @"Set the useSvmProps option in the [svn-remote] config."),
                    new GitCommandOption("--use-svnsync-props", @"--use-svnsync-props", @"Set the useSvnsyncProps option in the [svn-remote] config."),
                    new GitCommandOption("-v", @"-v", @"it's not completely compatible with the --verbose output in svn log, but reasonably close."),
                    new GitCommandOption("--verbose", @"--verbose", @"it's not completely compatible with the --verbose output in svn log, but reasonably close.")
                },
                "tag" => new[]
                {
                    new GitCommandOption("-a", @"-a", @"Make an unsigned, annotated tag object"),
                    new GitCommandOption("--annotate", @"--annotate", @"Make an unsigned, annotated tag object"),
                    new GitCommandOption("--cleanup", @"--cleanup=<mode>",
                        @"This option sets how the tag message is cleaned up. The <mode> can be one of verbatim, whitespace and strip. The strip mode is default. The verbatim mode does not change message at all, whitespace removes just leading/trailing whitespace lines and strip removes both whitespace and commentary."),
                    new GitCommandOption("--column", @"--column[=<options>]",
                        @"Display tag listing in columns. See configuration variable column.tag for option syntax.--column and --no-column without options are equivalent to always and never respectively.
This option is only applicable when listing tags without annotation lines."),
                    new GitCommandOption("--contains [<commit>]", @"--contains [<commit>]", @"Only list tags which contain the specified commit (HEAD if not specified)."),
                    new GitCommandOption("--create-reflog", @"--create-reflog", @"Create a reflog for the tag."),
                    new GitCommandOption("-d", @"-d", @"Delete existing tags with the given names."),
                    new GitCommandOption("--delete", @"--delete", @"Delete existing tags with the given names."),
                    new GitCommandOption("-F", @"-F <file>",
                        @"Take the tag message from the given file. Use - to read the message from the standard input. Implies -a if none of -a, -s, or -u <keyid> is given."),
                    new GitCommandOption("-f", @"-f", @"Replace an existing tag with the given name (instead of failing)"),
                    new GitCommandOption("--file", @"--file=<file>",
                        @"Take the tag message from the given file. Use - to read the message from the standard input. Implies -a if none of -a, -s, or -u <keyid> is given."),
                    new GitCommandOption("--force", @"--force", @"Replace an existing tag with the given name (instead of failing)"),
                    new GitCommandOption("-l", @"-l <pattern>",
                        @"List tags with names that match the given pattern (or all if no pattern is given). Running ""git tag"" without arguments also lists all tags. The pattern is a shell wildcard (i.e., matched using fnmatch(3)). Multiple patterns may be given; if any of them matches, the tag is shown."),
                    new GitCommandOption("--list", @"--list <pattern>",
                        @"List tags with names that match the given pattern (or all if no pattern is given). Running ""git tag"" without arguments also lists all tags. The pattern is a shell wildcard (i.e., matched using fnmatch(3)). Multiple patterns may be given; if any of them matches, the tag is shown."),
                    new GitCommandOption("--local-user", @"--local-user=<keyid>", @"Make a GPG-signed tag, using the given key."),
                    new GitCommandOption("-m", @"-m <msg>",
                        @"Use the given tag message (instead of prompting). If multiple -m options are given, their values are concatenated as separate paragraphs. Implies -a if none of -a, -s, or -u <keyid> is given."),
                    new GitCommandOption("--merged [<commit>]", @"--merged [<commit>]",
                        @"Only list tags whose tips are reachable, or not reachable if --no-merged is used, from the specified commit (HEAD if not specified)."),
                    new GitCommandOption("--message", @"--message=<msg>",
                        @"Use the given tag message (instead of prompting). If multiple -m options are given, their values are concatenated as separate paragraphs. Implies -a if none of -a, -s, or -u <keyid> is given."),
                    new GitCommandOption("-n<num>", @"-n<num>",
                        @"<num> specifies how many lines from the annotation, if any, are printed when using -l. The default is not to print any annotation lines. If no number is given to -n, only the first line is printed. If the tag is not annotated, the commit message is displayed instead."),
                    new GitCommandOption("--no-column", @"--no-column",
                        @"Display tag listing in columns. See configuration variable column.tag for option syntax.--column and --no-column without options are equivalent to always and never respectively.
This option is only applicable when listing tags without annotation lines."),
                    new GitCommandOption("--no-merged [<commit>]", @"--no-merged [<commit>]",
                        @"Only list tags whose tips are reachable, or not reachable if --no-merged is used, from the specified commit (HEAD if not specified)."),
                    new GitCommandOption("--points-at", @"--points-at <object>", @"Only list tags of the given object."),
                    new GitCommandOption("-s", @"-s", @"Make a GPG-signed tag, using the default e-mail address's key."),
                    new GitCommandOption("--sign", @"--sign", @"Make a GPG-signed tag, using the default e-mail address's key."),
                    new GitCommandOption("--sort", @"--sort=<key>",
                        @"Sort based on the key given. Prefix - to sort in descending order of the value. You may use the --sort=<key> option multiple times, in which case the last key becomes the primary key. Also supports ""version:refname"" or ""v:refname"" (tag names are treated as versions). The ""version:refname"" sort order can also be affected by the ""versionsort.prereleaseSuffix"" configuration variable. The keys supported are the same as those in git for-each-ref. Sort order defaults to the value configured for the tag.sort variable if it exists, or lexicographic order otherwise. See git-config[1]."),
                    new GitCommandOption("-u", @"-u <keyid>", @"Make a GPG-signed tag, using the given key."),
                    new GitCommandOption("-v", @"-v", @"Verify the GPG signature of the given tag names."),
                    new GitCommandOption("--verify", @"--verify", @"Verify the GPG signature of the given tag names.")
                },
                "restore" => new[] {
                    new GitCommandOption("-s", "-s <tree>", @"Restore the working tree files with the content from the given tree. It is common to specify the source tree by naming a commit, branch or tag associated with it.  If not specified, the contents are restored from HEAD if --staged is given, otherwise from the index."),
                    new GitCommandOption("--source", "--source=<tree>", @"Restore the working tree files with the content from the given tree. It is common to specify the source tree by naming a commit, branch or tag associated with it.  If not specified, the contents are restored from HEAD if --staged is given, otherwise from the index."),
                    new GitCommandOption("-p", "-p", @"Interactively select hunks in the difference between the restore source and the restore location. See the “Interactive Mode” section of git-add to learn how to operate the --patch mode.  Note that --patch can accept no pathspec and will prompt to restore all modified paths."),
                    new GitCommandOption("--patch", "--patch", @"Interactively select hunks in the difference between the restore source and the restore location. See the “Interactive Mode” section of git-add to learn how to operate the --patch mode.  Note that --patch can accept no pathspec and will prompt to restore all modified paths."),
                    new GitCommandOption("-W", "-W", @"Specify the restore location. If neither option is specified, by default the working tree is restored. Specifying --staged will only restore the index. Specifying both restores both."),
                    new GitCommandOption("--worktree", "--worktree", @"Specify the restore location. If neither option is specified, by default the working tree is restored. Specifying --staged will only restore the index. Specifying both restores both."),
                    new GitCommandOption("-S", "-S", @"Specify the restore location. If neither option is specified, by default the working tree is restored. Specifying --staged will only restore the index. Specifying both restores both."),
                    new GitCommandOption("--staged", "--staged", @"Specify the restore location. If neither option is specified, by default the working tree is restored. Specifying --staged will only restore the index. Specifying both restores both."),
                    new GitCommandOption("-q", "-q", @"Quiet, suppress feedback messages. Implies --no-progress."),
                    new GitCommandOption("--quiet", "--quiet", @"Quiet, suppress feedback messages. Implies --no-progress."),
                    new GitCommandOption("--progress", "--progress", @"Progress status is reported on the standard error stream by default when it is attached to a terminal, unless --quiet is specified. This flag enables progress reporting even if not attached to a terminal, regardless of --quiet."),
                    new GitCommandOption("--no-progress", "--no-progress", @"Progress status is reported on the standard error stream by default when it is attached to a terminal, unless --quiet is specified. This flag enables progress reporting even if not attached to a terminal, regardless of --quiet."),
                    new GitCommandOption("--ours", "--ours", @"When restoring files in the working tree from the index, use stage #2 (ours) or #3 (theirs) for unmerged paths.  Note that during git rebase and git pull --rebase, ours and theirs may appear swapped. See the explanation of the same options in git-checkout for details."),
                    new GitCommandOption("--theirs", "--theirs", @"When restoring files in the working tree from the index, use stage #2 (ours) or #3 (theirs) for unmerged paths.  Note that during git rebase and git pull --rebase, ours and theirs may appear swapped. See the explanation of the same options in git-checkout for details."),
                    new GitCommandOption("-m", "-m", @"When restoring files on the working tree from the index, recreate the conflicted merge in the unmerged paths."),
                    new GitCommandOption("--merge", "--merge", @"When restoring files on the working tree from the index, recreate the conflicted merge in the unmerged paths."),
                    new GitCommandOption("--conflict", "--conflict=<style>", @"The same as --merge option above, but changes the way the conflicting hunks are presented, overriding the merge.conflictStyle configuration variable.  Possible values are ""merge"" (default) and ""diff3"" (in addition to what is shown by ""merge"" style, shows the original contents)."),
                    new GitCommandOption("--ignore-unmerged", "--ignore-unmerged", @"When restoring files on the working tree from the index, do not abort the operation if there are unmerged entries and neither --ours, --theirs, --merge or --conflict is specified. Unmerged paths on the working tree are left alone."),
                    new GitCommandOption("--ignore-skip-worktree-bits", "--ignore-skip-worktree-bits", @"In sparse checkout mode, by default is to only update entries matched by <pathspec> and sparse patterns in $GIT_DIR/info/sparse-checkout. This option ignores the sparse patterns and unconditionally restores any files in <pathspec>."),
                    new GitCommandOption("--recurse-submodules", "--recurse-submodules", @"If <pathspec> names an active submodule and the restore location includes the working tree, the submodule will only be updated if this option is given, in which case its working tree will be restored to the commit recorded in the superproject, and any local modifications overwritten. If nothing (or --no-recurse-submodules) is used, submodules working trees will not be updated. Just like git-checkout, this will detach HEAD of the submodule."),
                    new GitCommandOption("--no-recurse-submodules", "--no-recurse-submodules", @"If <pathspec> names an active submodule and the restore location includes the working tree, the submodule will only be updated if this option is given, in which case its working tree will be restored to the commit recorded in the superproject, and any local modifications overwritten. If nothing (or --no-recurse-submodules) is used, submodules working trees will not be updated. Just like git-checkout, this will detach HEAD of the submodule."),
                    new GitCommandOption("--overlay", "--overlay", @"In overlay mode, the command never removes files when restoring. In no-overlay mode, tracked files that do not appear in the --source tree are removed, to make them match <tree> exactly. The default is no-overlay mode."),
                    new GitCommandOption("--no-overlay", "--no-overlay", @"In overlay mode, the command never removes files when restoring. In no-overlay mode, tracked files that do not appear in the --source tree are removed, to make them match <tree> exactly. The default is no-overlay mode."),
                    new GitCommandOption("--pathspec-from-file", "--pathspec-from-file=<file>", @"Pathspec is passed in <file> instead of commandline args. If <file> is exactly - then standard input is used. Pathspec elements are separated by LF or CR/LF. Pathspec elements can be quoted as explained for the configuration variable core.quotePath (see git-config). See also --pathspec-file-nul and global --literal-pathspecs."),
                    new GitCommandOption("--pathspec-file-nul", "--pathspec-file-nul", @"Only meaningful with --pathspec-from-file. Pathspec elements are separated with NUL character and all other characters are taken literally (including newlines and quotes)."),
                    new GitCommandOption("--", "--", @"Do not interpret any more arguments as options."),
                    new GitCommandOption("<pathspec>…​", "<pathspec>…​", @"Limits the paths affected by the operation.  For more details, see the pathspec entry in gitglossary."),
                },
                _ => resolveAliases ? TryGetOptionsFromAlias(name) : System.Array.Empty<GitCommandOption>()

            };
        }

        private static GitCommandOption[] TryGetOptionsFromAlias(string name) {
            var aliases = Git.GetAliases(name).ToArray();
            if (aliases.Length != 1) {
                return Array.Empty<GitCommandOption>();
            }

            var (alias, command, _) = aliases[0];
            return alias != name ? Array.Empty<GitCommandOption>() : GetOptions(command, false);
        }
    }
}