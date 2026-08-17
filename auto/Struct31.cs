internal struct UpdateDirectiveEntry
{
	public bool executeAfterApply;

	public bool mergeWithExistingFile;

	public bool targetsLocalMachineRegistry;

	public bool targetsCurrentUserRegistry;

	public bool downloadsPayload;

	public string targetPath;

	public string[] payloadLines;
}
