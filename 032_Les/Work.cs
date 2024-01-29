using System.Diagnostics;

internal class Work
{
	private float _progress;

	private readonly float _progressStep = 0.1f;
	private readonly ProgressBar _progressBar;

	public Work(ProgressBar progressBar, float progressStep = 0.1f)
	{
		_progressBar = progressBar;
		_progressStep = progressStep;

		_progress = 0;
		_progressBar.Draw((int)Math.Round(_progress * 100));
	}

	public async Task DoWorkAsync()
	{
		Stopwatch stopwatch = new();
		stopwatch.Start();
		while (_progress < 1)
		{
			await Task.Yield();
			float elapsed = stopwatch.ElapsedMilliseconds / 1000f;
			_progress = _progressStep * elapsed;
			_progressBar.Draw((int)Math.Round(_progress * 100));
		}
	}
}