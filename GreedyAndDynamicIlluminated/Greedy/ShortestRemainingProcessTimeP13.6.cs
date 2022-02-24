namespace GreedyAndDynamicIlluminated.Greedy
{
    /// <summary>
    /// P 13.5 Algorithm Illuminated Part 3
    /// Given jobs with duration l and release time r such that
    /// a job can be processed only at or after the release time
    /// jobs can be preemted - Find the schedule with minimum completion time
    /// 
    /// </summary>
    public class ShortestRemainingProcessTime
    {
        PriorityQueue<Job, int> remaining;
        Dictionary<int, Job> release;
        public ShortestRemainingProcessTime()
        {
            remaining = new PriorityQueue<Job, int>();
            release = new Dictionary<int, Job>();
        }
        public int MinCompletionTime(IEnumerable<Job> jobs)
        {
            jobs.ToList().Sort(new ReleaseComparer());
            int[] completionTime = new int[jobs.ToList().Count];
            // Fill the release
            FillRelease(jobs);
            int currentTime = 0;

            Job currentJob = jobs.ToList()[0];
            if(currentJob.Release <= currentTime)
            {
                remaining.Enqueue(currentJob, currentJob.Length);
            }
            int jobNum = 0;
            while(remaining.Count > 0)
            {
                var min = remaining.Dequeue();
                ProcessByUnit(1, min);
                currentTime++;
                if (release.TryGetValue(currentTime, out Job nextRelease))
                {
                    // push to the que
                    remaining.Enqueue(nextRelease, nextRelease.Length);
                }
                if (min.Length > 0) remaining.Enqueue(min, min.Length); // if not complete push to remaining queue for processing
                else completionTime[jobNum++] = currentTime;
            }

            return TotalCompletionTime(completionTime);
        }

        private void ProcessByUnit(int unit, Job job)
        {
            job.Length -= unit;
        }

        private void FillRelease(IEnumerable<Job> jobs)
        {
            foreach(var job in jobs)
            {
                release.Add(job.Release, job); // assuming only one job at one time
            }
        }

        int TotalCompletionTime(int[] completion)
        {
            int total = 0;
            for(int i = 0; i < completion.Length; i++)
            {
                total += completion[i];
            }

            return total;
        }
    }


    public class Job
    {
        public Job(int length, int release)
        {
            this.Length = length;
            this.Release = release;
        }
        public int Length { get; set; }
        public int Release { get; set; }
    }

   public class Comparer : IComparer<Job>
    {
        public int Compare(Job? x, Job? y) => x.Length - y.Length;
    }

    public class ReleaseComparer : IComparer<Job>
    {
        public int Compare(Job? x, Job? y) => x.Release - y.Release;
    }
}
