# Job Seeker Management Stored Procedure

This repository includes a stored procedure `proc_jobseeker` that manages job seeker data in a database. The procedure performs different actions based on the `@action` parameter, such as inserting new records, changing passwords, retrieving job seeker information, and blocking/unblocking job seekers.

## Procedure: `proc_jobseeker`

### Parameters:
- `@action` (varchar, optional): Action to be performed (e.g., `'INSERT'`, `'CP'`, `'jobseekerjoin'`, `'jobSeekerblock'`).
- `@jobseekerId` (int, optional): The unique identifier for the job seeker.
- `@jobseekerName` (varchar, optional): The name of the job seeker.
- `@jobseekerEmail` (varchar, optional): The email of the job seeker.
- `@jobseekerPassword` (varchar, optional): The current password of the job seeker.
- `@jobseekerNewPassword` (varchar, optional): The new password for the job seeker.
- `@jobseekerCurrentPassword` (varchar, optional): The current password for validation.
- `@jobseekerGender` (int, optional): The gender of the job seeker.
- `@jobseekerJobprofile` (int, optional): The job profile ID.
- `@jobseekerQualification` (int, optional): The qualification ID of the job seeker.
- `@jobseekerState` (int, optional): The state ID where the job seeker is located.
- `@jobseekerCity` (int, optional): The city ID where the job seeker is located.
- `@jobseekerQuestion` (int, optional): The security question ID.
- `@jobseekerAnswer` (varchar, optional): The answer to the security question.
- `@jobseekerDOB` (date, optional): The date of birth of the job seeker.
- `@jobseekerExp` (int, optional): The job seeker's experience in years.
- `@jobseekerImage` (varchar, optional): The file path or URL to the job seeker's image.
- `@jobseekerResume` (varchar, optional): The file path or URL to the job seeker's resume.
- `@jobseekerComments` (varchar, optional): Additional comments about the job seeker.

### Procedure Code:
```sql
CREATE PROCEDURE proc_jobseeker    
    @action VARCHAR(50) = NULL,    
    @jobseekerId INT = 0,    
    @jobseekerName VARCHAR(50) = NULL,    
    @jobseekerEmail VARCHAR(50) = NULL,    
    @jobseekerPassword VARCHAR(50) = NULL,    
    @jobseekerNewPassword VARCHAR(50) = NULL,  
    @jobseekerCurrentPassword VARCHAR(50) = NULL,  
    @jobseekerGender INT = 0,    
    @jobseekerJobprofile INT = 0,    
    @jobseekerQualification INT = 0,    
    @jobseekerState INT = 0,    
    @jobseekerCity INT = 0,    
    @jobseekerQuestion INT = 0,    
    @jobseekerAnswer VARCHAR(50) = NULL,    
    @jobseekerDOB DATE = NULL,    
    @jobseekerExp INT = 0,    
    @jobseekerImage VARCHAR(50) = NULL,    
    @jobseekerResume VARCHAR(50) = NULL,    
    @jobseekerComments VARCHAR(200) = NULL    
AS    
BEGIN    
    -- Insert a new job seeker
    IF (@action = 'INSERT')    
    BEGIN     
        INSERT INTO tbljobseeker(jobseekerName, jobseekerEmail, jobseekerPassword, jobseekerGender, jobseekerJobprofile,    
        jobseekerQualification, jobseekerState, jobseekerCity, jobseekerQuestion, jobseekerAnswer, jobseekerDOB,    
        jobseekerExp, jobseekerImage, jobseekerResume, jobseekerComments) 
        VALUES (@jobseekerName, @jobseekerEmail, @jobseekerPassword, @jobseekerGender, @jobseekerJobprofile, 
        @jobseekerQualification, @jobseekerState, @jobseekerCity, @jobseekerQuestion, @jobseekerAnswer, 
        @jobseekerDOB, @jobseekerExp, @jobseekerImage, @jobseekerResume, @jobseekerComments)    
    END    
    -- Change password for the job seeker
    ELSE IF (@action = 'CP')  
    BEGIN  
        UPDATE tbljobseeker 
        SET jobseekerPassword = @jobseekerNewPassword   
        WHERE jobseekerId = @jobseekerId AND jobseekerPassword = @jobseekerCurrentPassword   
    END  
    
    -- Retrieve joined job seeker information
    ELSE IF (@action = 'jobseekerjoin')    
    BEGIN    
        SELECT * FROM tbljobseeker    
        JOIN tbljobprofile ON jobseekerJobprofile = jobprofileId    
        JOIN tblqualification ON jobseekerQualification = qualificationId    
        JOIN tblcity ON jobseekerCity = cityId    
    END    
    
    -- Block or unblock a job seeker
    ELSE IF (@action = 'jobSeekerblock')  
    BEGIN  
        DECLARE @p INT  
        SELECT @p = jobseekerStatus FROM tbljobseeker WHERE jobseekerId = @jobseekerId  
        IF (@p = 0)  
        BEGIN  
            UPDATE tbljobseeker 
            SET jobseekerStatus = 1 
            WHERE jobseekerId = @jobseekerId  
        END  
        ELSE  
        BEGIN  
            UPDATE tbljobseeker 
            SET jobseekerStatus = 0 
            WHERE jobseekerId = @jobseekerId  
        END  
    END  
END
```

#-----------------------------------------------------------------------------------------------------------#
 Job Recruiter Management Stored Procedure

This repository includes a stored procedure `proc_JobRecruiter` designed to manage job recruiter data in a database. The procedure supports actions such as inserting new recruiters, blocking/unblocking recruiters, and updating recruiter information based on different actions defined by the `@action` parameter.

## Procedure: `proc_JobRecruiter`

### Parameters:
- `@action` (varchar, optional): Action to be performed (e.g., `'INSERT'`, `'jobrecruiterblock'`).
- `@JRId` (int, optional): The unique identifier for the recruiter.
- `@JRName` (varchar, optional): The name of the recruiter.
- `@JREmail` (varchar, optional): The email address of the recruiter.
- `@JRPassword` (varchar, optional): The password for the recruiter.
- `@JRURL` (varchar, optional): The URL associated with the recruiter (e.g., their company or profile URL).
- `@JRState` (int, optional): The state ID where the recruiter is located.
- `@JRCity` (int, optional): The city ID where the recruiter is located.
- `@JRAddress` (varchar, optional): The address of the recruiter.
- `@JRImage` (varchar, optional): The file path or URL to the recruiter's image.
- `@JRComment` (varchar, optional): Additional comments or notes about the recruiter.

### Procedure Code:

```sql
CREATE PROCEDURE proc_JobRecruiter    
    @action VARCHAR(50) = NULL,    
    @JRId INT = 0,    
    @JRName VARCHAR(50) = NULL,    
    @JREmail VARCHAR(50) = NULL,    
    @JRPassword VARCHAR(50) = NULL,    
    @JRURL VARCHAR(50) = NULL,    
    @JRState INT = 0,    
    @JRCity INT = 0,    
    @JRAddress VARCHAR(50) = NULL,    
    @JRImage VARCHAR(50) = NULL,    
    @JRComment VARCHAR(100) = NULL    
AS    
BEGIN    
    -- Insert a new recruiter
    IF (@action = 'INSERT')    
    BEGIN    
        INSERT INTO tbljobrecruiter (JRName, JREmail, JRPassword, JRURL, JRState, JRCity, JRAddress, JRImage, JRComment) 
        VALUES (@JRName, @JREmail, @JRPassword, @JRURL, @JRState, @JRCity, @JRAddress, @JRImage, @JRComment)    
    END    

    -- Block or unblock a job recruiter
    ELSE IF (@action = 'jobrecruiterblock')  
    BEGIN  
        DECLARE @p INT  
        SELECT @p = JRStatus FROM tbljobrecruiter WHERE JRId = @JRId  
        IF (@p = 0)  
        BEGIN  
            UPDATE tbljobrecruiter 
            SET JRStatus = 1 
            WHERE JRId = @JRId  
        END  
        ELSE  
        BEGIN  
            UPDATE tbljobrecruiter 
            SET JRStatus = 0 
            WHERE JRId = @JRId  
        END  
    END  
END
```
#---------------------------------------------------------------------------------------------------------#

# Job Post Management Stored Procedure

This repository includes a stored procedure `jobPost_proc` that manages job postings by recruiters in the database. The procedure supports various actions based on the `@action` parameter, including inserting, updating, retrieving job posts, and handling job post status (active/inactive).

## Procedure: `jobPost_proc`

### Parameters:
- `@action` (varchar, optional): Action to be performed (e.g., `'insert'`, `'update'`, `'EDIT'`, `'jobshow'`, `'jobshowAll'`, `'jobshowAllactive'`, `'searchjobpost'`, `'jobPostblock'`).
- `@JobPostId` (int, optional): The unique identifier for the job post.
- `@JobRecruiterId` (int, optional): The recruiter ID associated with the job post.
- `@JobPostJobProfileId` (varchar, optional): The job profile ID associated with the job post.
- `@JobPostMode` (int, optional): The mode of the job post (e.g., full-time, part-time).
- `@JobPostGender` (int, optional): Gender requirement for the job post (e.g., male, female).
- `@JobPostQualification` (varchar, optional): The qualification required for the job post.
- `@JobPostMinExp` (int, optional): Minimum experience required for the job post (in years).
- `@JobPostMaxExp` (int, optional): Maximum experience allowed for the job post (in years).
- `@JobPostMinSalary` (int, optional): Minimum salary offered for the job post.
- `@JobPostMaxSalary` (int, optional): Maximum salary offered for the job post.
- `@JobPostVacancy` (int, optional): Number of vacancies available for the job post.
- `@JobPostComments` (varchar, optional): Additional comments or details about the job post.

### Procedure Code:

```sql
CREATE PROCEDURE jobPost_proc  
    @action VARCHAR(50) = NULL,   
    @JobPostId INT = 0,  
    @JobRecruiterId INT = 0,  
    @JobPostJobProfileId VARCHAR(50) = NULL,  
    @JobPostMode INT = 0,  
    @JobPostGender INT = 0,  
    @JobPostQualification VARCHAR(50) = NULL,  
    @JobPostMinExp INT = 0,  
    @JobPostMaxExp INT = 0,  
    @JobPostMinSalary INT = 0,  
    @JobPostMaxSalary INT = 0,  
    @JobPostVacancy INT = 0,  
    @JobPostComments VARCHAR(2000) = NULL  
AS BEGIN  
    -- Insert a new job post
    IF (@action = 'insert')  
    BEGIN  
        INSERT INTO tblJobPost(JobRecruiterId, JobPostJobProfileId, JobPostMode, JobPostGender, JobPostQualification, 
                               JobPostMinExp, JobPostMaxExp, JobPostMinSalary, JobPostMaxSalary, JobPostVacancy, JobPostComments)
        VALUES(@JobRecruiterId, @JobPostJobProfileId, @JobPostMode, @JobPostGender, @JobPostQualification, 
               @JobPostMinExp, @JobPostMaxExp, @JobPostMinSalary, @JobPostMaxSalary, @JobPostVacancy, @JobPostComments)
    END   

    -- Update an existing job post
    ELSE IF(@action = 'update')  
    BEGIN  
        UPDATE tblJobPost 
        SET JobPostJobProfileId = @JobPostJobProfileId, JobPostMode = @JobPostMode, JobPostGender = @JobPostGender, 
            JobPostQualification = @JobPostQualification, JobPostMinExp = @JobPostMinExp, JobPostMaxExp = @JobPostMaxExp, 
            JobPostMinSalary = @JobPostMinSalary, JobPostMaxSalary = @JobPostMaxSalary, JobPostVacancy = @JobPostVacancy, 
            JobPostComments = @JobPostComments 
        WHERE JobPostId = @JobPostId  
    END   

    -- Retrieve a specific job post for editing
    ELSE IF(@action = 'EDIT')  
    BEGIN  
        SELECT * FROM tblJobPost WHERE JobPostId = @JobPostId  
    END   

    -- Retrieve job posts for a specific recruiter
    ELSE IF(@action = 'jobshow')  
    BEGIN  
        SELECT * FROM tblJobPost 
        JOIN tbljobprofile ON jobprofileId = JobPostJobProfileId  
        JOIN seekerGender ON sgid = JobPostGender  
        JOIN tbljobrecruiter ON JRId = JobRecruiterId  
        WHERE JRId = @JobRecruiterId  
    END   

    -- Retrieve all job posts
    ELSE IF(@action = 'jobshowAll')  
    BEGIN  
        SELECT * FROM tblJobPost 
        JOIN tbljobprofile ON jobprofileId = JobPostJobProfileId  
        JOIN seekerGender ON sgid = JobPostGender  
        JOIN tbljobrecruiter ON JRId = JobRecruiterId  
    END   

    -- Retrieve only active job posts
    ELSE IF(@action = 'jobshowAllactive')  
    BEGIN  
        SELECT * FROM tblJobPost 
        JOIN tbljobprofile ON jobprofileId = JobPostJobProfileId  
        JOIN seekerGender ON sgid = JobPostGender  
        JOIN tbljobrecruiter ON JRId = JobRecruiterId  
        WHERE JobPostStatus = 0  
    END   

    -- Search for job posts by job profile
    ELSE IF(@action = 'searchjobpost')  
    BEGIN  
        SELECT * FROM tblJobPost 
        JOIN tbljobprofile ON jobprofileId = JobPostJobProfileId  
        JOIN seekerGender ON sgid = JobPostGender  
        JOIN tbljobrecruiter ON JRId = JobRecruiterId  
        WHERE JobPostJobProfileId = @JobPostJobProfileId AND JobPostStatus = 0  
    END   

    -- Block or unblock a job post
    ELSE IF(@action = 'jobPostblock')  
    BEGIN  
        DECLARE @p INT  
        SELECT @p = JobPostStatus FROM tblJobPost WHERE JobPostId = @JobPostId  
        IF(@p = 0)  
        BEGIN  
            UPDATE tblJobPost SET JobPostStatus = 1 WHERE JobPostId = @JobPostId  
        END  
        ELSE  
        BEGIN  
            UPDATE tblJobPost SET JobPostStatus = 0 WHERE JobPostId = @JobPostId  
        END  
    END  
END
