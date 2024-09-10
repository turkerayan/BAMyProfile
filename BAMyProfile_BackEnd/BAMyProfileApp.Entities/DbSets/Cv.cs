using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class Cv : AuditableEntity
{
    /// <summary>
    /// CV'nin başlığı. Örneğin, "Yazılım Geliştirici CV" veya "Junior Developer".
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Aday hakkında kısa bir özet içeren profil bilgisi.
    /// </summary>
    public string Profile { get; set; } = null!;

    /// <summary>
    /// Bu CV'ye sahip olan öğrencinin benzersiz kimliği.
    /// </summary>
    public Guid StudentId { get; set; }

    /// <summary>
    /// Bu CV'nin sahibi olan öğrenciyi temsil eden referans öğe.
    /// </summary>
    public virtual Student? Student { get; set; }

    
    // Cv ve öğrenci arasında bire çok ilişki var 
    // Bir öğrencinin bir kaç cvsi olabilir ama bir cv sadece bir öğrenciye aittir.
    

}

