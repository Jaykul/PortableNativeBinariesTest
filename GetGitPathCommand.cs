using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace PortableModule
{
    [Cmdlet("Get","GitPath")]
    [OutputType(typeof(String))]
    public class GetGitPathCommand : PSCmdlet
    {
        [Parameter(
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Path { get; set; } = Environment.CurrentDirectory;

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteObject( LibGit2Sharp.Repository.Discover( Path ) );
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            // WriteObject(new FavoriteStuff {
            //     FavoriteNumber = FavoriteNumber,
            //     FavoritePet = FavoritePet
            // });
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            // WriteVerbose("End!");
        }
    }
}
