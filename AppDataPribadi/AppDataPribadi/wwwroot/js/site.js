// Fungsi untuk menampilkan form di modal
function ShowInPopup(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res); 
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal("show"); 
        },
        error: function () {
            alert("Gagal memuat form.");
        }
    });
}

// Fungsi untuk submit form menggunakan AJAX
function SubmitForm(form) {
    $.ajax({
        type: "POST",               
        url: form.action,          
        data: $(form).serialize(), 
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    icon: 'success',
                    title: 'Sukses!',
                    text: response.message,
                    confirmButtonText: 'OK',
                    confirmButtonColor: '#28a745',
                }).then(() => {
                    setTimeout(function () {
                        location.reload();
                    }, 5000);  // 5000 ms = 5 detik
                });
            } else {
                alert(response.message);
            }
        },
        error: function () {
            alert("Terjadi kesalahan saat mengirim data.");
        }
    });

    return false;
}


function EditForm(form) {
    $.ajax({
        type: "POST",
        url: form.action,  
        data: $(form).serialize(),
        dataType: 'json', 
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    icon: 'success',
                    title: 'Sukses!',
                    text: response.message,
                    confirmButtonText: 'OK',
                    confirmButtonColor: '#28a745',
                }).then((result) => {
                    // Set waktu untuk refresh halaman setelah 5 detik
                    if (result.isConfirmed) {
                        setTimeout(function () {
                            location.reload(); // Reload halaman setelah 5 detik
                        }, 5000); // 5000 ms = 5 detik
                    }
                });
            } else {
                
                Swal.fire({
                    icon: 'error',
                    title: 'Gagal!',
                    text: response.message,
                    confirmButtonText: 'OK',
                    confirmButtonColor: '#dc3545',
                });
            }
        },
        error: function (xhr, status, error) {
            // Log kesalahan jika terjadi error pada AJAX
            console.error("Error: ", status, error);
            Swal.fire({
                icon: 'error',
                title: 'Error!',
                text: "Terjadi kesalahan saat mengirim data. Silakan coba lagi.",
                confirmButtonText: 'OK',
                confirmButtonColor: '#dc3545',
            });
        }
    });
    return false; // Mencegah form melakukan submit standar
}


// Call EditForm when document is ready
$(document).ready(function () {
    $('#searchButton').click(function () {
        var nik = $('#nik').val().toLowerCase();
        var nama = $('#nama').val().toLowerCase();

        $('#tablePerson tbody tr').each(function () {
            var rowNIK = $(this).find('td:eq(1)').text().toLowerCase();  // Kolom NIK
            var rowNama = $(this).find('td:eq(2)').text().toLowerCase();  // Kolom Nama

            // Periksa apakah NIK atau Nama cocok dengan pencarian
            var isMatch = true;
            if (nik && rowNIK.indexOf(nik) === -1) {
                isMatch = false; 
            }
            if (nama && rowNama.indexOf(nama) === -1) {
                isMatch = false; 
            }

            
            if (isMatch) {
                $(this).show(); 
            } else {
                $(this).hide();  
            }
        });
    });
});




