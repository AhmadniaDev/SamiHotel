function fetchSecureData() {
    fetch('/api/Secure', {
        method: 'GET',
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        }
    })
        .then(async res => {
            if (!res.ok) {
                let error = await res.json().catch(() => ({ error: "خطای ناشناخته" }));
                throw error;
            }
            return res.json();
        })
        .then(data => {
            // نمایش پیام موفقیت در مودال
            $('#Modalbody').text(data.message);
            $('#MyModal').modal('show');  // باز کردن مودال با بوت‌استر
        })
        .catch(error => {
            // نمایش پیام خطا در مودال
            $('#Modalbody').text(error.error || "خطایی رخ داده");
            $('#MyModal').modal('show');  // باز کردن مودال
        });
}
