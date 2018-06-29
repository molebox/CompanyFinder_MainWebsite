namespace Competence.ViewModels
{
    /// <summary>
    /// View model to represent the skills model
    /// </summary>
    public class AddSkillsViewModel
    {   
        /// <summary>
        /// Skill id
        /// </summary>
        public int SkillId { get; set; }
        /// <summary>
        /// Skill name
        /// </summary>
        public string SkillName { get; set; }
        /// <summary>
        /// Bool to check if the db successfully added the new skill to the db. Not currently in use
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Constructor to set the success bool to false as default
        /// </summary>
        public AddSkillsViewModel()
        {
            Success = false;
        }
  
    }
}
